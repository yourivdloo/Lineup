using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logics.Entities;
using Data.Dtos;

namespace Logics.Mappers
{
    public static class IdentityMapper
    {
        static IdentityMapper()
            {
                Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<IdentityMapperProfile>(); }).CreateMapper();
            }

            internal static IMapper Mapper { get; }

            public static ApplicationUser ToEntity(this ApplicationUserDto user)
        {
            return user == null ? null : Mapper.Map<ApplicationUser>(user);
        }

        public static ApplicationUserDto ToModel(this ApplicationUser user)
        {
            return user == null ? null : Mapper.Map<ApplicationUserDto>(user);
        }
    }
}
