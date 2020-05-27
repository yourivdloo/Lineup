using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Lineup.Data.Dtos;
using Lineup.Logics.Classes;
using Lineup.Logics.Mappers;

namespace StrikeNet.BusinessLogic.Mappers
{
    public static class PlayerMappers
    {
        static PlayerMappers()
        {
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<PlayerMapperProfile>(); }).CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Player ToEntity(this PlayerDto game)
        {
            return game == null ? null : Mapper.Map<Player>(game);
        }

        public static PlayerDto ToModel(this Player game)
        {
            return game == null ? null : Mapper.Map<PlayerDto>(game);
        }
    }
}