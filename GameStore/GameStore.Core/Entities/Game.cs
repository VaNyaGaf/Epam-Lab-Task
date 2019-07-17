using System.Collections.Generic;

namespace GameStore.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public IList<Comment> Comments { get; set; }

        public IList<GameGenres> GameGenres { get; set; }

        public IList<GamePlatformTypes> GamePlatformTypes { get; set; }
    }
}
