using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class SubregionConfiguration : EntityConfiguration<Subregion>
{
    public override void Configure(EntityTypeBuilder<Subregion> builder)
    {
        base.Configure(builder);

        builder.ToTable("Subregion");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(s => s.Translations)
            .HasColumnName("translations")
            .HasColumnType("text");

        builder.Property(s => s.RegionId)
            .HasColumnName("region_id");

        builder.HasOne(s => s.Region)
            .WithMany(r => r.Subregions)
            .HasForeignKey(s => s.RegionId);

        builder.Property(s => s.Flag)
            .HasColumnName("flag");

        builder.Property(s => s.WikiDataId)
            .HasMaxLength(255)
            .HasColumnName("wikiDataId");

        builder.HasMany(s => s.Countries)
            .WithOne(c => c.SubregionEntity)
            .HasForeignKey(c => c.SubregionId);

        builder.HasIndex(s => s.Code)
            .IsUnique()
            .HasDatabaseName("up_subregion_code");
    }
}