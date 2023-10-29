using System.Reflection.Metadata.Ecma335;

namespace API.Model.Domain
{
    public class User
    {
        public Guid id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public string Password { get; set; }

    }
}
