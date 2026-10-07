using Microsoft.EntityFrameworkCore;
using MusicTw.Domain.Entities;

namespace MusicTw.Application.Abstractions.Persistence;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<Song> Songs { get; }
    DbSet<Post> Posts { get; }
    DbSet<Comment> Comments { get; }
    DbSet<PostLike> PostLikes { get; }
    DbSet<Follow> Follows { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
