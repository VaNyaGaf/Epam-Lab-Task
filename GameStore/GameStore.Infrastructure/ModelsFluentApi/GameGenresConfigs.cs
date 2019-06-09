using GameStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Infrastructure.ModelsFluentApi
{
    class GameGenresConfigs : IEntityTypeConfiguration<GameGenres>
    {
        public void Configure(EntityTypeBuilder<GameGenres> builder)
        {
            builder.HasKey(gg => new { gg.GameId, gg.GenreId });

            builder.HasOne(gg => gg.Game)
                .WithMany(game => game.GameGenres)
                .HasForeignKey(gg => gg.GameId);

            builder.HasOne(gg => gg.Genre)
                .WithMany(genre => genre.GameGenres)
                .HasForeignKey(gg => gg.GenreId);
        }
    }
}
