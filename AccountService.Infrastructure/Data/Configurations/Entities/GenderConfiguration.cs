using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class GenderConfiguration : EntityConfiguration<Gender>
{
    public override void Configure(EntityTypeBuilder<Gender> builder)
    {
        base.Configure(builder);

        builder.ToTable("Gender");
        
        builder.Property(e => e.GenderValue)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("gender");
    }
}