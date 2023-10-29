using API.Model.Domain;

namespace API.Repo
{
    public interface IImage
    {
        Task<Image> upload(Image   image);
    }
}
