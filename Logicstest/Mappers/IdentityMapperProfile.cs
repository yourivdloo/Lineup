using System;
using System.Collections.Generic;
using System.Text;
using Logics.Entities;
using Data.Dtos;
using AutoMapper;

namespace Logics.Mappers
{
    public class IdentityMapperProfile : Profile 
    {
        public IdentityMapperProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>(MemberList.Destination);

            CreateMap<ApplicationUserDto, ApplicationUser>(MemberList.Source);
        }
    }
}
