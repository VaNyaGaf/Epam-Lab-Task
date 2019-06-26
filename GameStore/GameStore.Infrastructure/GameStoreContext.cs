using GameStore.Core.Entities;
using GameStore.Infrastructure.ModelsFluentApi;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure
{
    public class GameStoreContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlatformTypes> GamePlatformTypes { get; set; }
        public DbSet<GameGenres> GameGenres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreConfigs());
            modelBuilder.ApplyConfiguration(new GameGenresConfigs());
            modelBuilder.ApplyConfiguration(new GamePlatformTypesConfigs());
            modelBuilder.ApplyConfiguration(new PlatformTypeConfigs());
            modelBuilder.ApplyConfiguration(new PublisherConfigs());
        }
    }
}
