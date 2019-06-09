using System.Collections.Generic;

namespace GameStore.Core.Entities
{
    public class PlatformType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public IList<GamePlatformTypes> GamePlatformTypes { get; set; }
    }
}
