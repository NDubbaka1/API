using API.Model.Domain;

namespace API.Repo
{
    public interface IWalkDiffRepo
    {

        Task<IEnumerable<WalkDiffculty>> GetAllWalkDiff();
    }
}
