using Microsoft.EntityFrameworkCore;
using Veilig.Entities;

namespace Veilig.DbContexts
{
    public class VeiligContext : DbContext
    {
        public VeiligContext(DbContextOptions<VeiligContext> options): base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Slug will have UNIQUE constraint
            builder.Entity<Paste>(entity => 
            {
                entity.HasIndex(e => e.Slug).IsUnique();
            });
        }

        public DbSet<Paste> Pastes { get; set; }
    }
}