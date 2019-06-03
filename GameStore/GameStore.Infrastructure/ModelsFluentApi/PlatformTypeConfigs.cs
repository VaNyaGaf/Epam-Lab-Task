using GameStore.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Infrastructure.ModelsFluentApi
{
    class PlatformTypeConfigs : IEntityTypeConfiguration<PlatformType>
    {
        public void Configure(EntityTypeBuilder<PlatformType> builder)
        {
            builder.HasAlternateKey(p => p.Type);
            builder.Property(p => p.Type).IsRequired();
        }
    }
}
