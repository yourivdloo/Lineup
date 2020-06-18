using AutoMapper;
using Data.Dtos;
using Logics.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logics.Mappers
{
    public static class TeamMapper
    {
        static TeamMapper()
        {
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<TeamMapperProfile>(); }).CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static TeamDto ToModel(this Team team)
        {
            return team == null ? null : Mapper.Map<TeamDto>(team);
        }

        public static Team ToEntity(this TeamDto team)
        {
            return team == null ? null : Mapper.Map<Team>(team);
        }

    }
}
