using MusicTw.Api.Configuration;
using MusicTw.Infrastructure;
using MusicTw.Application.Abstractions.Services;
using MusicTw.Application.Features.Auth;
using MusicTw.Application.Features.Comments;
using MusicTw.Application.Features.Feed;
using MusicTw.Application.Features.Likes;
using MusicTw.Application.Features.Posts;
using MusicTw.Application.Features.Profiles;
using MusicTw.Application.Features.Songs;
using MusicTw.Application.Features.Follows;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.Local.json", optional: true, reloadOnChange: true);

var corsOptions = builder.Configuration.GetSection(CorsOptions.SectionName).Get<CorsOptions>() ?? new CorsOptions();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IFeedService, FeedService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (corsOptions.AllowedOrigins.Count > 0)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Frontend", policy =>
        {
            policy.WithOrigins(corsOptions.AllowedOrigins.ToArray())
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

if (corsOptions.AllowedOrigins.Count > 0)
{
    app.UseCors("Frontend");
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
