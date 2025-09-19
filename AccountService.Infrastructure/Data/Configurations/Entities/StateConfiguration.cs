using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class StateConfiguration : EntityConfiguration<State>
{
    public override void Configure(EntityTypeBuilder<State> builder)
    {
        base.Configure(builder);

        builder.ToTable("State");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("name");

        builder.Property(s => s.CountryId)
            .HasColumnName("country_id");

        builder.HasOne(s => s.Country)
            .WithMany(c => c.States)
            .HasForeignKey(s => s.CountryId);

        builder.Property(s => s.CountryCode)
            .IsRequired()
            .HasMaxLength(2)
            .HasColumnName("country_code");

        builder.Property(s => s.FipsCode)
            .HasMaxLength(255)
            .HasColumnName("fips_code");

        builder.Property(s => s.Iso2)
            .HasMaxLength(255)
            .HasColumnName("iso2");

        builder.Property(s => s.Iso3166_2)
            .HasMaxLength(10)
            .HasColumnName("iso3166_2");

        builder.Property(s => s.Type)
            .HasMaxLength(191)
            .HasColumnName("type");

        builder.Property(s => s.Level)
            .HasColumnName("level");

        builder.Property(s => s.ParentId)
            .HasColumnName("parent_id");

        builder.Property(s => s.Native)
            .HasMaxLength(255)
            .HasColumnName("native");

        builder.Property(s => s.Latitude)
            .HasColumnName("latitude")
            .HasColumnType("decimal(10,8)");

        builder.Property(s => s.Longitude)
            .HasColumnName("longitude")
            .HasColumnType("decimal(11,8)");

        builder.Property(s => s.Timezone)
            .HasMaxLength(255)
            .HasColumnName("timezone");

        builder.Property(s => s.Flag)
            .HasColumnName("flag");

        builder.Property(s => s.WikiDataId)
            .HasMaxLength(255)
            .HasColumnName("wikiDataId");

        builder.HasMany(s => s.Cities)
            .WithOne(c => c.State)
            .HasForeignKey(c => c.StateId);

        builder.HasIndex(s => s.Code)
            .IsUnique()
            .HasDatabaseName("up_state_code");
    }
}