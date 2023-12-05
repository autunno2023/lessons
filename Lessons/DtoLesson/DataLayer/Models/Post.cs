using System.Collections.Generic;

namespace DataLayer.Models
{
    internal class Post
    {
        public string Id { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
