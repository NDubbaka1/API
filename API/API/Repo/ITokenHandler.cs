using API.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Repo
{
    public interface ITokenHandler 
    {
        string CreateJWToken(IdentityUser identityUser, List<string> roles);
    }
}
