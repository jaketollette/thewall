namespace CodingDojoWall.Models.Entities
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}