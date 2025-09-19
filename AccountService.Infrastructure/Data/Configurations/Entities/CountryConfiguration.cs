using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class CountryConfiguration : EntityConfiguration<Country>
{
    public override void Configure(EntityTypeBuilder<Country> builder)
    {
        base.Configure(builder);

        builder.ToTable("Country");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(c => c.Iso3)
            .HasMaxLength(3)
            .HasColumnName("iso3");

        builder.Property(c => c.NumericCode)
            .HasMaxLength(3)
            .HasColumnName("numeric_code");

        builder.Property(c => c.Iso2)
            .HasMaxLength(2)
            .HasColumnName("iso2");

        builder.Property(c => c.PhoneCode)
            .HasMaxLength(255)
            .HasColumnName("phonecode");

        builder.Property(c => c.Capital)
            .HasMaxLength(255)
            .HasColumnName("capital");

        builder.Property(c => c.Currency)
            .HasMaxLength(255)
            .HasColumnName("currency");

        builder.Property(c => c.CurrencyName)
            .HasMaxLength(255)
            .HasColumnName("currency_name");

        builder.Property(c => c.CurrencySymbol)
            .HasMaxLength(255)
            .HasColumnName("currency_symbol");

        builder.Property(c => c.Tld)
            .HasMaxLength(255)
            .HasColumnName("tld");

        builder.Property(c => c.Native)
            .HasMaxLength(255)
            .HasColumnName("native");

        builder.Property(c => c.Region)
            .HasMaxLength(255)
            .HasColumnName("region");

        builder.Property(c => c.RegionId)
            .HasColumnName("region_id");

        builder.HasOne(c => c.RegionEntity)
            .WithMany(r => r.Countries)
            .HasForeignKey(c => c.RegionId);

        builder.Property(c => c.Subregion)
            .HasMaxLength(255)
            .HasColumnName("subregion");

        builder.Property(c => c.SubregionId)
            .HasColumnName("subregion_id");

        builder.HasOne(c => c.SubregionEntity)
            .WithMany(s => s.Countries)
            .HasForeignKey(c => c.SubregionId);

        builder.Property(c => c.Nationality)
            .HasMaxLength(255)
            .HasColumnName("nationality");

        builder.Property(c => c.Timezones)
            .HasColumnName("timezones")
            .HasColumnType("text");

        builder.Property(c => c.Translations)
            .HasColumnName("translations")
            .HasColumnType("text");

        builder.Property(c => c.Latitude)
            .HasColumnName("latitude")
            .HasColumnType("decimal(10,8)");

        builder.Property(c => c.Longitude)
            .HasColumnName("longitude")
            .HasColumnType("decimal(11,8)");

        builder.Property(c => c.Emoji)
            .HasMaxLength(191)
            .HasColumnName("emoji");

        builder.Property(c => c.EmojiU)
            .HasMaxLength(191)
            .HasColumnName("emojiU");

        builder.Property(c => c.Flag)
            .HasColumnName("flag");

        builder.Property(c => c.WikiDataId)
            .HasMaxLength(255)
            .HasColumnName("wikiDataId");

        builder.HasMany(c => c.States)
            .WithOne(s => s.Country)
            .HasForeignKey(s => s.CountryId);

        builder.HasIndex(c => c.Code)
            .IsUnique()
            .HasDatabaseName("up_country_code");
    }
}