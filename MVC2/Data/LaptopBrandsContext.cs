using System;
using Microsoft.EntityFrameworkCore;

namespace MVC2.Models
{
	public class LaptopBrandsContext: DbContext
	{
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Laptop> Laptops { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Database=LaptopBrands2;Integrated Security=false;User ID=sa;Password=MyPass@word;TrustServerCertificate=true;");
        }
        public LaptopBrandsContext(DbContextOptions<LaptopBrandsContext> options)
            : base(options)
        {
        }
    }
}

