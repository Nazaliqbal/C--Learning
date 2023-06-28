using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsersController : Controller
    {
        private readonly MovieContext _context;

        public UserService UserService { get; }

        public UsersController(UserService _userService)
        {
   
            UserService = _userService;
            _context = UserService.dbContext;
        }

        // GET: Users
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            return await UserService.GetUsersAsync();
        }
        [HttpGet("{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<User>> GetUserbyId(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user=await UserService.GetUserbyIdAsync(id);
            if (user == null) { 
                return NotFound();
            }
            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdUser = await UserService.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await UserService.UpdateUserAsync(id, updatedUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle the exception and return an appropriate response
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await UserService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
