using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace L.DataAccess.Concrete.EntityFramework
{
    public class EfLContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=10.147.17.3;Database=Al;User Id=enis.ertnrkl;Password=402624;TrustServerCertificate=true;");
        }
    }
}
