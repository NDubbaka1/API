using AutoMapper;

namespace API.Profiles
{
    public class InfoProfile : Profile
    {

        public InfoProfile()
        {
            CreateMap<Model.Domain.Info, Model.DTO.Info>().
               ReverseMap();
        }
    }
}
