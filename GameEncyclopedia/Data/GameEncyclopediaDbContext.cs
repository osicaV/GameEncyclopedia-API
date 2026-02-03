using GameEncyclopedia.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameEncyclopedia.Data {
    public class GameEncyclopediaDbContext : DbContext {
        public GameEncyclopediaDbContext(DbContextOptions<GameEncyclopediaDbContext> options) : base(options) {
            
        }

        public DbSet<Monster> Monsters => Set<Monster>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Monster>(e => {
                e.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

                e.HasIndex(m => m.Name)
                .IsUnique();
            });
        }
    }
}
