namespace GameStore.DAL.Models
{
    public class GamePlatformTypes
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int PlatformTypeId { get; set; }
        public PlatformType PlatformType { get; set; }
    }
}
