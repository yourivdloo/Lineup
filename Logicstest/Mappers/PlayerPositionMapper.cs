using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logics.Entities;
using Lineup.Logics.Mappers;
using Data.Dtos;

namespace Lineup.Logics.Mappers
{
    public static class PlayerPositionMapper
    {
        static PlayerPositionMapper()
        {
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<PlayerPositionMapperProfile>(); }).CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static PlayerPosition ToEntity(this PlayerPositionDto playerPositionDto)
        {
            return playerPositionDto == null ? null : Mapper.Map<PlayerPosition>(playerPositionDto);
        }

        public static PlayerPositionDto ToModel(this PlayerPosition playerPosition)
        {
            return playerPosition == null ? null : Mapper.Map<PlayerPositionDto>(playerPosition);
        }
    }
}