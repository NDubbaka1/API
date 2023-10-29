using API.Model.Domain;
namespace API.Repo
{
    public interface IInfoRepo
    {
        Task<IEnumerable<Info>> GetAllInfoAsync();

        Task<Info> GetInfoById(int id);

        Task<Info> AddInfo(Info info);

        Task<Info> DeleteInfoById(int id);

        Task<Info> UpdateInfoById(int id, Info info);
    }
}
