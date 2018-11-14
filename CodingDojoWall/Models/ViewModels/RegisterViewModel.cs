using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingDojoWall.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do no match")]
        public string ConfirmPassword { get; set; }
    }
}