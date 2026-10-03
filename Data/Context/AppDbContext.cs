using CosmeticServer.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CosmeticServer.API.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
