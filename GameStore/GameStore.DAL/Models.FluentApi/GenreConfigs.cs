using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Models.FluentApi
{
    class GenreConfigs : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasAlternateKey(g => g.Name);
            builder.Property(g => g.Name).IsRequired();
        }
    }
}
