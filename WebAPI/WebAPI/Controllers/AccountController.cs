using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        /// <summary>
        /// Retrieves all roles from the database.
        /// </summary>
        /// <returns>A list of roles.</returns>
        /// <response code="200">Returns the list of roles.</response>
        [HttpGet]

        public async Task<IActionResult> GetRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return Ok(roles);
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userManager.Users.Select(u => new UserDTO
            {
                UserName = u.UserName,
                Email = u.Email,
            }).ToListAsync();

            return Ok(users);
        }
        /// <summary>
        /// A list of users based on their roles.
        /// </summary>
        /// <returns>A list of users based on their roles.</returns>
        /// <response code="200">Returns the list of users based on their roles.</response>

        [HttpGet("users/{roleName}")]
        public async Task<IActionResult> GetUsersByRole(string roleName)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                return NotFound($"Role ${roleName} does not exist.");
            }
            var usersInRole = await userManager.GetUsersInRoleAsync(roleName);

            var usersToDisplay = usersInRole.Select(user => new
            {
                user.Email,
                user.UserName
            });

            return Ok(usersToDisplay);
        }
        [HttpGet("role-ids")]
        public async Task<IActionResult> GetRoleIds()
        {
            var roles = await roleManager.Roles.ToListAsync();
            var roleIds = new List<string>();

            foreach (var role in roles)
            {
                roleIds.Add(role.Id);
            }

            return Ok(roleIds);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterView model)
        {
            var roles = new[] { "Admin", "Manager", "User", "Guest" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = model.Role;

                if (role == "Admin" || role == "Manager" || role == "User" || role == "Guest")

                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    return BadRequest("Invalid role specified.");
                }

                var token = GenerateJwtToken(user, role);
                var message = "Successfully registered.";
                return Ok(new { Message=message,Token = token });
            }
            else
            {
                return NotFound(result);
            }
        }
        private string GenerateJwtToken(IdentityUser user, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

}



