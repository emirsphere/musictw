using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTw.Domain.Entities;

namespace MusicTw.Infrastructure.Persistence.Configurations;

public class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder.ToTable("Follows", tableBuilder =>
        {
            tableBuilder.HasCheckConstraint("CK_Follows_NoSelfFollow", "[FollowerId] <> [FollowingId]");
        });

        builder.HasKey(x => new { x.FollowerId, x.FollowingId });

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.Follower)
            .WithMany(x => x.Following)
            .HasForeignKey(x => x.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Following)
            .WithMany(x => x.Followers)
            .HasForeignKey(x => x.FollowingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.FollowingId);
    }
}
