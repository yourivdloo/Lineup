using System;
using System.Collections.Generic;
using System.Text;
using Logics.Services.Interfaces;
using Data.Repositories.Interfaces;
using System.Threading.Tasks;
using Logics.Entities;
using Data.Dtos;
using Lineup.Logics.Mappers;

namespace Logics.Services
{
    public class FormationService : IFormationService
    {
        private readonly IFormationRepository IFormationRepository;
        public FormationService(IFormationRepository iFormationRepository)
        {
            IFormationRepository = iFormationRepository;
        }

        public async Task<List<Formation>> GetAllFormations(int teamId)
        {
            List<FormationDto> formationDtos = await IFormationRepository.GetAllFormations(teamId);
            List<Formation> formations = new List<Formation>();
            foreach (FormationDto dto in formationDtos)
            {
                formations.Add(dto.ToEntity());
            }
            return formations;
        }

        public async Task<List<Player>> GetAllPlayers(int teamId)
        {
            List<PlayerDto> playerDtos = await IFormationRepository.GetAllPlayers(teamId);
            List<Player> players = new List<Player>();
            foreach (PlayerDto dto in playerDtos)
            {
                players.Add(dto.ToEntity());
            }
            return players;
        }

    }
}
