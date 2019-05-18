using System.Collections.Generic;

namespace GameStore.DAL.Models
{
    public class PlatformType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<GamePlatformTypes> GamePlatformTypes { get; set; }
    }
}
