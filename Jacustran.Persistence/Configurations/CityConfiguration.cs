using Jacustran.Domain.Entity.Entities;

namespace Jacustran.Persistence.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p  => p.Description)
            .HasMaxLength(200);
    }
}
