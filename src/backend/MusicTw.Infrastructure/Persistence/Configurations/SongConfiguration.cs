using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicTw.Domain.Entities;
using MusicTw.Infrastructure.Persistence.Seed;

namespace MusicTw.Infrastructure.Persistence.Configurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("Songs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Artist)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Album)
            .HasMaxLength(200);

        builder.Property(x => x.CoverImageUrl)
            .HasMaxLength(500);

        builder.Property(x => x.Duration)
            .IsRequired();

        builder.Property(x => x.IsSeeded)
            .IsRequired();

        builder.HasData(SongSeedData.All);
    }
}
