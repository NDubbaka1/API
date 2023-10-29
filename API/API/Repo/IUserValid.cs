using API.Model;

namespace API.Repo
{
    public interface IUserValid
    {
        Task<bool> ValidateUser(string Username, string password);
    }
}
