using System.Collections.Generic;

namespace CodingDojoWall.Models.Entities
{
    public class Message : Entity
    {
        public string Content { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
}