using AcortURL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AcortURL.Data
{
    public class UrlsShortenerContext : DbContext
    {
        public DbSet<URL> Urls { get; set; }
        public DbSet<CategoriasURL> CategoriasURL { get; set; }

        public DbSet<User> Users { get; set; }
        public UrlsShortenerContext(DbContextOptions<UrlsShortenerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriasURL>()
                .HasMany(c => c.URLs)
                .WithOne(u => u.Categoria)
                .HasForeignKey(u => u.CategoriaId);

            User user = new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                Role = Models.Enum.Role.Admin
            };
                
                
            base.OnModelCreating(modelBuilder);
        }
    }
}

