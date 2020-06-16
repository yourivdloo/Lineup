using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logics.Entities;
using Data.Dtos;

namespace Lineup.Logics.Mappers
{
    public class PlayerPositionMapperProfile : Profile
    {

        public PlayerPositionMapperProfile()
        {
            CreateMap<PlayerPosition, PlayerPositionDto>(MemberList.Destination);

            // model to entity
            CreateMap<PlayerPositionDto, PlayerPosition>(MemberList.Source);
        }
    }
}