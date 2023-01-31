using API.Model.Domain;

namespace API.Repo
{
    public interface IWalkRepo 
    {

        Task<IEnumerable<Walk>> GetWalkByID();

        Task<Walk> GetWalkByID(Guid id);
    }
}
