
using AutoMapper;
namespace API.Profiles
{
    public class WalkProfile: Profile
    {

        public WalkProfile()
        {
            CreateMap<Model.Domain.Walk, Model.DTO.Walk>().ReverseMap();
        }
    }
}
