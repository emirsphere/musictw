using MusicTw.Domain.Entities;

namespace MusicTw.Infrastructure.Persistence.Seed;

public static class SongSeedData
{
    public static readonly Song[] All =
    {
        new()
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Title = "Billie Jean",
            Artist = "Michael Jackson",
            Album = "Thriller",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 4, 54),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Title = "Thriller",
            Artist = "Michael Jackson",
            Album = "Thriller",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 5, 57),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Title = "Heal the World",
            Artist = "Michael Jackson",
            Album = "Dangerous",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 6, 25),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Title = "Dancing Machine",
            Artist = "Jackson 5",
            Album = "G.I.T.: Get It Together",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 2, 39),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Title = "She's Out of My Life",
            Artist = "Michael Jackson",
            Album = "Off the Wall",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 3, 38),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            Title = "The Girl Is Mine",
            Artist = "Michael Jackson, Paul McCartney",
            Album = "Thriller",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 3, 42),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            Title = "They Don’t Care About Us",
            Artist = "Michael Jackson",
            Album = "HIStory: Past, Present and Future, Book I",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 4, 44),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            Title = "Man in the Mirror",
            Artist = "Michael Jackson",
            Album = "Bad 25",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 5, 19),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
            Title = "Don’t Stop ’Til You Get Enough",
            Artist = "Michael Jackson",
            Album = "Off the Wall",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 6, 5),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Title = "Rock with You",
            Artist = "Michael Jackson",
            Album = "Off the Wall",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 3, 40),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
            Title = "Earth Song",
            Artist = "Michael Jackson",
            Album = "HIStory: Past, Present and Future, Book I",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 6, 46),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
            Title = "We Are the World",
            Artist = "USA for Africa",
            Album = "We Are the World",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 7, 12),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
            Title = "Will You Be There",
            Artist = "Michael Jackson",
            Album = "Dangerous",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 7, 40),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
            Title = "Beat It",
            Artist = "Michael Jackson",
            Album = "Thriller",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 4, 18),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
            Title = "Dirty Diana",
            Artist = "Michael Jackson",
            Album = "Bad",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 4, 52),
            IsSeeded = true
        },
        new()
        {
            Id = Guid.Parse("12345678-1234-1234-1234-123456789012"),
            Title = "The Way You Make Me Feel",
            Artist = "Michael Jackson",
            Album = "Bad 25",
            CoverImageUrl = "",
            Duration = new TimeSpan(0, 4, 58),
            IsSeeded = true
        }
    };
}
