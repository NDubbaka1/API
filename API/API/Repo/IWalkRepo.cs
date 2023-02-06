using API.Model.Domain;

namespace API.Repo
{
    public interface IWalkRepo 
    {

        Task<IEnumerable<Walk>> GetWalkByID();

        Task<Walk> GetWalkByID(Guid id);

        Task<Walk> AddWalkByID(Walk walk);

        Task<Walk> UpdateWalkById(Guid  id, Walk   walk );
    }
}
