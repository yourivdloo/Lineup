using System;
using System.Collections.Generic;
using System.Text;
using Logics.Services.Interfaces;
using Data.Repositories.Interfaces;
using System.Threading.Tasks;
using Logics.Entities;
using Data.Dtos;
using Lineup.Logics.Mappers;
using Data.Enums;

namespace Logics.Services
{
    public class FormationService : IFormationService
    {
        private readonly IFormationRepository _formationRepository;
        public FormationService(IFormationRepository iFormationRepository)
        {
            _formationRepository = iFormationRepository;
        }

        public async Task<List<Formation>> GetAllFormations(int teamId)
        {
            List<FormationDto> formationDtos = await _formationRepository.GetAllFormations(teamId);
            List<Formation> formations = new List<Formation>();
            foreach (FormationDto dto in formationDtos)
            {
                formations.Add(dto.ToEntity());
            }
            return formations;
        }

        public async Task<int> AddFormation(Formation formation)
        {
            return await _formationRepository.AddFormation(formation.ToModel());
        }

        public async Task<int> AddPlayerPosition(PlayerPosition pp)
        {
            return await _formationRepository.AddPlayerPosition(pp.ToModel());
        }

        public async Task DeleteFormation(int id)
        {
            await _formationRepository.DeleteFormation(id);
        }

        public async Task EditFormation(Formation formation)
        {
            await _formationRepository.EditFormation(formation.ToModel());
        }

        public async Task EditPlayerPosition(PlayerPosition pp)
        {
            await _formationRepository.EditPlayerPosition(pp.ToModel());
        }

        public async Task<List<PlayerPosition>> GetAllPlayerPositions(int id)
        {
            List<PlayerPositionDto> ppDtos = await _formationRepository.GetAllPlayerPositions(id);
            List<PlayerPosition> playerPositions = new List<PlayerPosition>();
            foreach (var ppDto in ppDtos)
            {
                playerPositions.Add(ppDto.ToEntity());
            }
            return (playerPositions);
            
        }

        public async Task<PlayerPosition> GetPlayerPosition(int playerPositionId)
        {
            PlayerPositionDto ppDto = await _formationRepository.GetPlayerPosition(playerPositionId);
            return (ppDto.ToEntity());
        }

        public async Task<Formation> GetFormation(int id)
        {
            FormationDto formationDto = await _formationRepository.GetFormation(id);
            return (formationDto.ToEntity());
        }

        public List<string> CheckFormation(List<Position> positions)
        {
            List<Position> fieldPlayers = new List<Position>();
            List<Position> goalkeepers = new List<Position>();
            List<string> errors = new List<string>();
            foreach (var position in positions)
            {
                if (position != Position.Substitute)
                {
                    fieldPlayers.Add(position);
                }
                if (position == Position.Goalkeeper)
                {
                    goalkeepers.Add(position);
                }
            }
            if (fieldPlayers.Count != 11)
            {
                errors.Add("You need exactly 11 field players");
            }
            if (goalkeepers.Count != 1)
            {
                errors.Add("You need exactly 1 goalkeeper");
            }
            return errors;
        }

    }
}
