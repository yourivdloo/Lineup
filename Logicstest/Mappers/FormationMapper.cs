using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logics.Entities;
using Lineup.Logics.Mappers;
using Data.Dtos;
using Logics.Mappers;

namespace Lineup.Logics.Mappers
{
    public static class FormationMapper
    {
        static FormationMapper()
        {
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<FormationMapperProfile>(); }).CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Formation ToEntity(this FormationDto formation)
        {
            return formation == null ? null : Mapper.Map<Formation>(formation);
        }

        public static PlayerDto ToModel(this Player player)
        {
            return player == null ? null : Mapper.Map<PlayerDto>(player);
        }
    }
}