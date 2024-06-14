using Microsoft.EntityFrameworkCore;
using MvcTraining.Models.Entities;

namespace MvcTraining.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
