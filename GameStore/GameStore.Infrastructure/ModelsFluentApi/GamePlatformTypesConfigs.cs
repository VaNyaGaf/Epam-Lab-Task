using GameStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Infrastructure.ModelsFluentApi
{
    class GamePlatformTypesConfigs : IEntityTypeConfiguration<GamePlatformTypes>
    {
        public void Configure(EntityTypeBuilder<GamePlatformTypes> builder)
        {
            builder.HasKey(gp => new { gp.GameId, gp.PlatformTypeId });

            builder.HasOne(gp => gp.Game)
                .WithMany(game => game.GamePlatformTypes)
                .HasForeignKey(gp => gp.GameId);

            builder.HasOne(gp => gp.PlatformType)
                .WithMany(platform => platform.GamePlatformTypes)
                .HasForeignKey(gp => gp.PlatformTypeId);
        }
    }
}
