using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GameGenres> GameGenres { get; set; }
    }
}
