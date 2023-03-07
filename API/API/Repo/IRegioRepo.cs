using API.Model.Domain;

namespace API.Repo
{
    public interface IRegioRepo
    {
       Task<IEnumerable<Region>> GetAllRegionAsync();

        Task<Region> GetRegionByIDAsync(Guid id);

        Task<Region> AddRegionAsync(Region region);

        Task<Region> DeleteRegionByID(Guid id);

        Task<Region> UpdateRegionByID(Guid id, Region region);
    }
}
