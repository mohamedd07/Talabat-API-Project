﻿using AutoMapper;
using Talabat.API.DTOs;
using Talabat.Core.Entities;

namespace Talabat.API.Helpers
{
    public class MappingProfiles : Profile
    {


        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                //.ForMember(P => P.PictureUrl, o => o.MapFrom(S => $"/{S.PictureUrl}"));
                .ForMember(P => P.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
