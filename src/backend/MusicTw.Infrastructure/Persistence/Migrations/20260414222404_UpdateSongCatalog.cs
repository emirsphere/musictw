using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicTw.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSongCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Thriller", "Michael Jackson", "", new TimeSpan(0, 0, 4, 54, 0), "Billie Jean" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-1234-1234-123456789012"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Bad 25", "Michael Jackson", "", new TimeSpan(0, 0, 4, 58, 0), "The Way You Make Me Feel" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Thriller", "Michael Jackson", "", new TimeSpan(0, 0, 5, 57, 0), "Thriller" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Dangerous", "Michael Jackson", "", new TimeSpan(0, 0, 6, 25, 0), "Heal the World" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "G.I.T.: Get It Together", "Jackson 5", "", new TimeSpan(0, 0, 2, 39, 0), "Dancing Machine" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Off the Wall", "Michael Jackson", "", new TimeSpan(0, 0, 3, 38, 0), "She's Out of My Life" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Thriller", "Michael Jackson, Paul McCartney", "", new TimeSpan(0, 0, 3, 42, 0), "The Girl Is Mine" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "HIStory: Past, Present and Future, Book I", "Michael Jackson", "", new TimeSpan(0, 0, 4, 44, 0), "They Don’t Care About Us" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Bad 25", "Michael Jackson", "", new TimeSpan(0, 0, 5, 19, 0), "Man in the Mirror" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Off the Wall", "Michael Jackson", "", new TimeSpan(0, 0, 6, 5, 0), "Don’t Stop ’Til You Get Enough" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Off the Wall", "Michael Jackson", "", new TimeSpan(0, 0, 3, 40, 0), "Rock with You" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "HIStory: Past, Present and Future, Book I", "Michael Jackson", "", new TimeSpan(0, 0, 6, 46, 0), "Earth Song" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "We Are the World", "USA for Africa", "", new TimeSpan(0, 0, 7, 12, 0), "We Are the World" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Dangerous", "Michael Jackson", "", new TimeSpan(0, 0, 7, 40, 0), "Will You Be There" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Thriller", "Michael Jackson", "", new TimeSpan(0, 0, 4, 18, 0), "Beat It" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Bad", "Michael Jackson", "", new TimeSpan(0, 0, 4, 52, 0), "Dirty Diana" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "After Hours", "The Weeknd", "https://images.example.com/covers/blinding-lights.jpg", new TimeSpan(0, 0, 3, 20, 0), "Blinding Lights" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-1234-1234-123456789012"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Rave & Roses", "Rema, Selena Gomez", "https://images.example.com/covers/calm-down.jpg", new TimeSpan(0, 0, 3, 39, 0), "Calm Down" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Future Nostalgia", "Dua Lipa", "https://images.example.com/covers/levitating.jpg", new TimeSpan(0, 0, 3, 23, 0), "Levitating" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Harry's House", "Harry Styles", "https://images.example.com/covers/as-it-was.jpg", new TimeSpan(0, 0, 2, 47, 0), "As It Was" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "WHEN WE ALL FALL ASLEEP, WHERE DO WE GO?", "Billie Eilish", "https://images.example.com/covers/bad-guy.jpg", new TimeSpan(0, 0, 3, 14, 0), "bad guy" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Divide", "Ed Sheeran", "https://images.example.com/covers/shape-of-you.jpg", new TimeSpan(0, 0, 3, 53, 0), "Shape of You" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Hollywood's Bleeding", "Post Malone", "https://images.example.com/covers/circles.jpg", new TimeSpan(0, 0, 3, 35, 0), "Circles" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Fine Line", "Harry Styles", "https://images.example.com/covers/watermelon-sugar.jpg", new TimeSpan(0, 0, 2, 54, 0), "Watermelon Sugar" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "F*CK LOVE 3: OVER YOU", "The Kid LAROI, Justin Bieber", "https://images.example.com/covers/stay.jpg", new TimeSpan(0, 0, 2, 21, 0), "Stay" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "SOUR", "Olivia Rodrigo", "https://images.example.com/covers/good-4-u.jpg", new TimeSpan(0, 0, 2, 58, 0), "Good 4 U" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Justice", "Justin Bieber", "https://images.example.com/covers/peaches.jpg", new TimeSpan(0, 0, 3, 18, 0), "Peaches" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Midnights", "Taylor Swift", "https://images.example.com/covers/anti-hero.jpg", new TimeSpan(0, 0, 3, 20, 0), "Anti-Hero" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Endless Summer Vacation", "Miley Cyrus", "https://images.example.com/covers/flowers.jpg", new TimeSpan(0, 0, 3, 20, 0), "Flowers" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Lover", "Taylor Swift", "https://images.example.com/covers/cruel-summer.jpg", new TimeSpan(0, 0, 2, 58, 0), "Cruel Summer" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "Spider-Man: Into the Spider-Verse", "Post Malone, Swae Lee", "https://images.example.com/covers/sunflower.jpg", new TimeSpan(0, 0, 2, 38, 0), "Sunflower" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                columns: new[] { "Album", "Artist", "CoverImageUrl", "Duration", "Title" },
                values: new object[] { "After Hours", "The Weeknd", "https://images.example.com/covers/save-your-tears.jpg", new TimeSpan(0, 0, 3, 35, 0), "Save Your Tears" });
        }
    }
}
