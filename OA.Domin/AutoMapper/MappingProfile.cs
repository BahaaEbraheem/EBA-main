using AutoMapper;
using OA.Domin.Administration;
using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.AutoMapper
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
         
          //  CreateMap<PersonType, AdministrationBoardVM>()
          //.ForMember(dest => dest.PersonType.PTypeId, opt => opt.MapFrom(src => src.PTypeId)).ReverseMap();

        }
    }
}
