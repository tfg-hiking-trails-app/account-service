using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class RegionConfiguration : EntityConfiguration<Region>
{
    public override void Configure(EntityTypeBuilder<Region> builder)
    {
        base.Configure(builder);

        builder.ToTable("Region");

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(r => r.Translations)
            .HasColumnName("translations")
            .HasColumnType("text");

        builder.Property(r => r.Flag)
            .HasColumnName("flag");

        builder.Property(r => r.WikiDataId)
            .HasMaxLength(255)
            .HasColumnName("wikiDataId");

        builder.HasMany(r => r.Countries)
            .WithOne(c => c.RegionEntity)
            .HasForeignKey(c => c.RegionId);

        builder.HasIndex(r => r.Code)
            .IsUnique()
            .HasDatabaseName("up_region_code");
    }
}