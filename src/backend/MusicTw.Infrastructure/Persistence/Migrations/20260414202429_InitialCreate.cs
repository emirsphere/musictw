using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicTw.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Album = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsSeeded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    FollowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => new { x.FollowerId, x.FollowingId });
                    table.CheckConstraint("CK_Follows_NoSelfFollow", "[FollowerId] <> [FollowingId]");
                    table.ForeignKey(
                        name: "FK_Follows_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follows_Users_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostLikes",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLikes", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostLikes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "CoverImageUrl", "Duration", "IsSeeded", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "After Hours", "The Weeknd", "https://images.example.com/covers/blinding-lights.jpg", new TimeSpan(0, 0, 3, 20, 0), true, "Blinding Lights" },
                    { new Guid("12345678-1234-1234-1234-123456789012"), "Rave & Roses", "Rema, Selena Gomez", "https://images.example.com/covers/calm-down.jpg", new TimeSpan(0, 0, 3, 39, 0), true, "Calm Down" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Future Nostalgia", "Dua Lipa", "https://images.example.com/covers/levitating.jpg", new TimeSpan(0, 0, 3, 23, 0), true, "Levitating" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Harry's House", "Harry Styles", "https://images.example.com/covers/as-it-was.jpg", new TimeSpan(0, 0, 2, 47, 0), true, "As It Was" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "WHEN WE ALL FALL ASLEEP, WHERE DO WE GO?", "Billie Eilish", "https://images.example.com/covers/bad-guy.jpg", new TimeSpan(0, 0, 3, 14, 0), true, "bad guy" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Divide", "Ed Sheeran", "https://images.example.com/covers/shape-of-you.jpg", new TimeSpan(0, 0, 3, 53, 0), true, "Shape of You" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Hollywood's Bleeding", "Post Malone", "https://images.example.com/covers/circles.jpg", new TimeSpan(0, 0, 3, 35, 0), true, "Circles" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Fine Line", "Harry Styles", "https://images.example.com/covers/watermelon-sugar.jpg", new TimeSpan(0, 0, 2, 54, 0), true, "Watermelon Sugar" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "F*CK LOVE 3: OVER YOU", "The Kid LAROI, Justin Bieber", "https://images.example.com/covers/stay.jpg", new TimeSpan(0, 0, 2, 21, 0), true, "Stay" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "SOUR", "Olivia Rodrigo", "https://images.example.com/covers/good-4-u.jpg", new TimeSpan(0, 0, 2, 58, 0), true, "Good 4 U" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Justice", "Justin Bieber", "https://images.example.com/covers/peaches.jpg", new TimeSpan(0, 0, 3, 18, 0), true, "Peaches" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Midnights", "Taylor Swift", "https://images.example.com/covers/anti-hero.jpg", new TimeSpan(0, 0, 3, 20, 0), true, "Anti-Hero" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Endless Summer Vacation", "Miley Cyrus", "https://images.example.com/covers/flowers.jpg", new TimeSpan(0, 0, 3, 20, 0), true, "Flowers" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Lover", "Taylor Swift", "https://images.example.com/covers/cruel-summer.jpg", new TimeSpan(0, 0, 2, 58, 0), true, "Cruel Summer" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Spider-Man: Into the Spider-Verse", "Post Malone, Swae Lee", "https://images.example.com/covers/sunflower.jpg", new TimeSpan(0, 0, 2, 38, 0), true, "Sunflower" },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), "After Hours", "The Weeknd", "https://images.example.com/covers/save-your-tears.jpg", new TimeSpan(0, 0, 3, 35, 0), true, "Save Your Tears" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedAt",
                table: "Comments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowingId",
                table: "Follows",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_UserId",
                table: "PostLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedAt",
                table: "Posts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SongId",
                table: "Posts",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "PostLikes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
