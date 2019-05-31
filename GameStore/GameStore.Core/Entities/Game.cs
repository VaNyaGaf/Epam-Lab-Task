namespace GameStore.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int PublisherId { get; set; }
    }
}
