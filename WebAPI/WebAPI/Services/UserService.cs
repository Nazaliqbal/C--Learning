using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;



namespace WebAPI.Services
{
    public class UserService
    {
        public readonly MovieContext dbContext;

        public UserService(MovieContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<ActionResult<User>> GetUserbyIdAsync(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            // Check if the email already exists in the table
            bool emailExists = await dbContext.Users.AnyAsync(u => u.Email == user.Email);
            if (emailExists)
            {
                // Throw an exception or return an error message
                throw new Exception("Email already taken");
            }

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return user;
        }
        public async Task UpdateUserAsync(int id, User updatedUser)
        {
            var existingUser = await dbContext.Users.FindAsync(id);
            if (existingUser == null)
            {
                throw new Exception("user Not found"); // Custom exception for not found
            }

            // Update the properties of the existing user
            existingUser.FullName = updatedUser.FullName;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;

            dbContext.Entry(existingUser).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();   
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found"); // Custom exception for not found
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
