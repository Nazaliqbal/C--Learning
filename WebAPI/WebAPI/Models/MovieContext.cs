using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class MovieContext:IdentityDbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

    }
}
