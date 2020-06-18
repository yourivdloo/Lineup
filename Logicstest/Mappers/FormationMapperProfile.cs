using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logics.Entities;
using Data.Dtos;

namespace Lineup.Logics.Mappers
{
    public class FormationMapperProfile : Profile
    {

        public FormationMapperProfile()
        {
            CreateMap<Formation, FormationDto>(MemberList.Destination);

            CreateMap<FormationDto, Formation>(MemberList.Source);
        }
    }
}