using API.Model.Domain;

namespace API.Repo
{
    public class StaticUserValidation : IUserValid
    {

        private List<User> users= new List<User>()
        {
            new User()
            { id = Guid.NewGuid(),
                Username= "Dubbakz",
                FirstName = "Narender",
                LastName = "Dubbaka",
                Email ="ndubbaka123@gmail.com",
                Password ="Qwerty@123",
                Roles = new List<string> {"Admin"}


            },
            new User() {id = Guid.NewGuid(),
                Username= "Tallapeni",
                FirstName = "Nagarjuna",
                LastName = "tallapaneni",
                Email ="ntallapaneni@gmail.com",
                Password ="Q@zwsxedc@123",
                Roles = new List<string> {"Reader","Writer"}
            }

            };
        public async Task<bool> ValidateUser(string Username, string password)
        {
            var user = users.Find(x => x.Username.Equals(Username, StringComparison.InvariantCultureIgnoreCase)
            && x.Password == password);

            if (user == null)
            { return false; }
            return  true;
        }
    }
}
