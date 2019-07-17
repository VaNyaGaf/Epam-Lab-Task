using GameStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Infrastructure.ModelsFluentApi
{
    internal class GenreConfigs : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(g => g.Name).IsUnique();
            builder.Property(g => g.Name).IsRequired();
        }
    }
}
