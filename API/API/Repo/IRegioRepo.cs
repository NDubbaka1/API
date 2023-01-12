using API.Model.Domain;

namespace API.Repo
{
    public interface IRegioRepo
    {
       IEnumerable<Region> GetAllRegion();
    }
}
