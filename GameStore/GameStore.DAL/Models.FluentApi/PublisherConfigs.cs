using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Models.FluentApi
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
