using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class AccountConfiguration : EntityConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Account");
        
        builder.HasOne(a => a.Gender)
            .WithMany(g => g.Accounts)
            .HasForeignKey(a => a.GenderId);

        builder.Property(a => a.GenderId)
            .HasColumnName("gender_id");

        builder.Property(a => a.Username)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("username");

        builder.Property(a => a.FirstName)
            .HasMaxLength(50)
            .HasColumnName("first_name");

        builder.Property(a => a.LastName)
            .HasMaxLength(50)
            .HasColumnName("last_name");
        
        builder.Property(a => a.CountryCode)
            .HasMaxLength(50)
            .HasColumnName("country_code");
        
        builder.Property(a => a.StateCode)
            .HasMaxLength(50)
            .HasColumnName("state_code");
        
        builder.Property(a => a.CityCode)
            .HasMaxLength(50)
            .HasColumnName("city_code");
        
        builder.Property(a => a.Biography)
            .HasColumnName("biography");

        builder.Property(a => a.DateOfBirth)
            .HasColumnName("date_of_birth")
            .HasColumnType("date");

        builder.Property(a => a.Weight)
            .HasColumnName("weight")
            .HasColumnType("decimal(5,2)");

        builder.Property(a => a.Height)
            .HasColumnName("height")
            .HasColumnType("decimal(5,2)");

        builder.Property(a => a.ProfilePicture)
            .HasMaxLength(255)
            .HasColumnName("profile_picture");
        
        builder.Property(a => a.Deleted)
            .HasColumnName("deleted");
        
        builder.HasIndex(a => a.Code)
            .IsUnique()
            .HasDatabaseName("up_account_code");
    }
}