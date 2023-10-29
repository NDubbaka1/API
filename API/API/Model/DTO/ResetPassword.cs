using System.ComponentModel.DataAnnotations;

namespace API.Model.DTO
{
    public class ResetPassword
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Newpassword { get; set; }
    }
}
