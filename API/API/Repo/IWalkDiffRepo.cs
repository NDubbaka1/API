using API.Model.Domain;

namespace API.Repo
{
    public interface IWalkDiffRepo
    {

        Task<IEnumerable<WalkDiffculty>> GetAllWalkDiff();

        Task<WalkDiffculty> GetWalkDiffculty(Guid id);

        Task<WalkDiffculty> AddWalkDiffculty(WalkDiffculty walkDiffculty);
    }
}
