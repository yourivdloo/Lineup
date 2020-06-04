using AutoMapper;
using Data.Dtos;
using Logics.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logics.Mappers
{
    public class TeamMapperProfile : Profile
    {
        public TeamMapperProfile()
        {
            CreateMap<Team, TeamDto>(MemberList.Destination);

            CreateMap<List<TeamDto>, List<Team>>(MemberList.Source);

            // model to entity
            CreateMap<TeamDto, Team>(MemberList.Source);
        }
    }
}
