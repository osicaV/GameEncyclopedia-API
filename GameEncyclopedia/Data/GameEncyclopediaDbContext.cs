using GameEncyclopedia.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameEncyclopedia.Data {
    public class GameEncyclopediaDbContext : DbContext {
        public GameEncyclopediaDbContext(DbContextOptions<GameEncyclopediaDbContext> options) : base(options) {
            
        }

        public DbSet<Monster> Monsters => Set<Monster>();
    }
}
