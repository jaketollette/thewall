using System.Collections.Generic;

namespace CodingDojoWall.Models.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual IList<Message> Messages { get; set; }
    }
}