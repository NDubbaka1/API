using AutoMapper;
namespace API.Profiles
{
    public class WalkDiffcultyProfile :Profile
    {
        public WalkDiffcultyProfile()
        {
            CreateMap<Model.Domain.WalkDiffculty, Model.DTO.WalkDiffculty>().ReverseMap();
        }
    }
}
