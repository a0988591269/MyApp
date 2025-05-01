using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Data
{
    public static class DataSeed
    {
        private static readonly Guid[] _guids =
        {
            Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Guid.Parse("22222222-2222-2222-2222-222222222222")
        };

        public static Player[] Players { get; } =
        {
            new Player
            {
                Id = _guids[0],
                Account = "ma2021",
                AccountType = "Free",
                CreatedDate = new DateTime(2021, 1, 1)
            },
            new Player
            {
                Id = _guids[1],
                Account = "dc2021",
                AccountType = "Free",
                CreatedDate = new DateTime(2021, 1, 2)
            }
        };

        public static Character[] Characters { get; } =
        {
            new Character
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Nickname = "Code Man",
                Classes = "Mage",
                Level = 99,
                PlayerId = _guids[0],
                CreatedDate = new DateTime(2021, 1, 3)
            },
            new Character
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Nickname = "Iron Man",
                Classes = "Warrior",
                Level = 90,
                PlayerId = _guids[0],
                CreatedDate = new DateTime(2021, 1, 3)
            },
            new Character
            {
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                Nickname = "Spider Man",
                Classes = "Druid",
                Level = 80,
                PlayerId = _guids[0],
                CreatedDate = new DateTime(2021, 1, 3)
            },
            new Character
            {
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                Nickname = "BatMan",
                Classes = "Death Knight",
                Level = 90,
                PlayerId = _guids[1],
                CreatedDate = new DateTime(2021, 1, 3)
            },
            new Character
            {
                Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                Nickname = "Super Man",
                Classes = "Paladin",
                Level = 99,
                PlayerId = _guids[1],
                CreatedDate = new DateTime(2021, 1, 3)
            }
        };
    }
}
