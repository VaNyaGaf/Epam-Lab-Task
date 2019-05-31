namespace GameStore.Core.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }
    }
}
