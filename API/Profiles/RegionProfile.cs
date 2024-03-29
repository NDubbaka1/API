﻿using AutoMapper;

namespace API.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Model.Domain.Region, Model.DTO.Region>().
                ReverseMap() ;
        }
    }
}
