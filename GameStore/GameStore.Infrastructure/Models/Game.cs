using System.Collections.Generic;

namespace GameStore.Infrastructure.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<GameGenres> GameGenres { get; set; }

        public ICollection<GamePlatformTypes> GamePlatformTypes { get; set; }
    }
}
