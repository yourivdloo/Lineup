using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logics.Entities;
using Lineup.Logics.Mappers;
using Data.Dtos;

namespace Lineup.Logics.Mappers
{
    public static class PlayerMappers
    {
        static PlayerMappers()
        {
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<PlayerMapperProfile>(); }).CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Player ToEntity(this PlayerDto player)
        {
            return player == null ? null : Mapper.Map<Player>(player);
        }

        public static PlayerDto ToModel(this Player player)
        {
            return player == null ? null : Mapper.Map<PlayerDto>(player);
        }
    }
}