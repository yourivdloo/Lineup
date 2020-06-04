﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logics.Entities;
using Data.Dtos;

namespace Lineup.Logics.Mappers
{
    public class PlayerMapperProfile : Profile
    {

        public PlayerMapperProfile()
        {
            CreateMap<Player, PlayerDto>(MemberList.Destination);

            // model to entity
            CreateMap<PlayerDto, Player>(MemberList.Source);
        }
    }
}