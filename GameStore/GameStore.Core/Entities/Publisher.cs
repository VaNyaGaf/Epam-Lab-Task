using System.Collections.Generic;

namespace GameStore.Core.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Game> Games { get; set; }
    }
}
