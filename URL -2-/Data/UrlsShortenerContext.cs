using AcortURL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AcortURL.Data
{
    public class UrlsShortenerContext : DbContext
    {
        public DbSet<URL> Urls { get; set; }
        

        public DbSet<User> Users { get; set; }
        public UrlsShortenerContext(DbContextOptions<UrlsShortenerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
                
            base.OnModelCreating(modelBuilder);
        }
    }
}

