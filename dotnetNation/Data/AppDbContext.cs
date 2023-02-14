using dotnetNation.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetNation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        public DbSet<Post> Posts { get; set; }
    }
}
