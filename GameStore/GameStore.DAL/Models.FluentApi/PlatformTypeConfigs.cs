using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Models.FluentApi
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
