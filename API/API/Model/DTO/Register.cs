using System.ComponentModel.DataAnnotations;

namespace API.Model.DTO
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles{get; set; }
    }
}
