namespace GameStore.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public int? ParentCommentId { get; set; }

        public int GameId { get; set; }
    }
}
