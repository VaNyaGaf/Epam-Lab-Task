using System.Collections.Generic;

namespace GameStore.Infrastructure.Models
{
    public class PlatformType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<GamePlatformTypes> GamePlatformTypes { get; set; }
    }
}
