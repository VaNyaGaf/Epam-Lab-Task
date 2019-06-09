using System.Collections.Generic;

namespace GameStore.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        public IList<Comment> Replies { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
