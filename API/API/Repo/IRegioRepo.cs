using API.Model.Domain;

namespace API.Repo
{
    public interface IRegioRepo
    {
       Task<IEnumerable<Region>> GetAllRegionAsync();
    }
}
