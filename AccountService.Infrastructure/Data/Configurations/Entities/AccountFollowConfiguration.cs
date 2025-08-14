using AccountService.Domain.Entities;
using Common.Infrastructure.Data.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.Data.Configurations.Entities;

public class AccountFollowConfiguration : EntityConfiguration<AccountFollow>
{
    public override void Configure(EntityTypeBuilder<AccountFollow> builder)
    {
        base.Configure(builder);

        builder.ToTable("AccountFollow");

        builder.Property(af => af.FollowerAccountId)
            .HasColumnName("follower_account_id");
        
        builder.HasOne(af => af.FollowerAccount)
            .WithMany(a => a.Following)
            .HasForeignKey(af => af.FollowerAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(af => af.FollowedAccountId)
            .HasColumnName("followed_account_id");
        
        builder.HasOne(af => af.FollowedAccount)
            .WithMany(a => a.Followers)
            .HasForeignKey(af => af.FollowedAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}