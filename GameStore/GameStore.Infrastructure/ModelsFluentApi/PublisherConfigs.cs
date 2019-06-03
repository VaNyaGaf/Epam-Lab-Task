using GameStore.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Infrastructure.ModelsFluentApi
{
    class PublisherConfigs : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasAlternateKey(p => p.Name);
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
