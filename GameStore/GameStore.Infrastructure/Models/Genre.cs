using System.Collections.Generic;

namespace GameStore.DAL.Abstractions.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }
        public Genre ParentGenre { get; set; }

        public IList<Genre> SubGenres { get; set; }

        public ICollection<GameGenres> GameGenres { get; set; }
    }
}
