using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class CityConfiguration : EntityConfiguration<City>
{
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        base.Configure(builder);

        builder.ToTable("City");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("name");

        builder.Property(c => c.StateId)
            .HasColumnName("state_id");

        builder.HasOne(c => c.State)
            .WithMany(s => s.Cities)
            .HasForeignKey(c => c.StateId);

        builder.Property(c => c.StateCode)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("state_code");

        builder.Property(c => c.CountryId)
            .HasColumnName("country_id");

        builder.HasOne(c => c.Country)
            .WithMany()
            .HasForeignKey(c => c.CountryId);

        builder.Property(c => c.CountryCode)
            .IsRequired()
            .HasMaxLength(2)
            .HasColumnName("country_code");

        builder.Property(c => c.Latitude)
            .IsRequired()
            .HasColumnName("latitude")
            .HasColumnType("decimal(10,8)");

        builder.Property(c => c.Longitude)
            .IsRequired()
            .HasColumnName("longitude")
            .HasColumnType("decimal(11,8)");

        builder.Property(c => c.Timezone)
            .HasMaxLength(255)
            .HasColumnName("timezone");

        builder.Property(c => c.Flag)
            .HasColumnName("flag");

        builder.Property(c => c.WikiDataId)
            .HasMaxLength(255)
            .HasColumnName("wikiDataId");

        builder.HasIndex(c => c.Code)
            .IsUnique()
            .HasDatabaseName("up_city_code");
    }
}