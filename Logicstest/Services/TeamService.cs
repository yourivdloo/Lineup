using System;
using System.Collections.Generic;
using System.Text;
using Data.Dtos;
using Logics.Entities;
using Logics.Services.Interfaces;
using Data.Repositories.Interfaces;
using System.Threading.Tasks;
using Logics.Mappers;

namespace Logics.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _TeamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _TeamRepository = teamRepository;
        }
        
        public async Task<List<Team>> GetAllTeams(Guid userId)
        {
            List<TeamDto> TeamDtos = await _TeamRepository.GetAllTeams(userId);
            List<Team> teams = new List<Team>();
            foreach (TeamDto team in TeamDtos)
            {
                teams.Add(team.ToEntity());
            }
            //List<Team> Teams = TeamDtos.ToEntity();
            return teams;
        }

        public async Task AddTeam(Team team)
        {
            TeamDto teamDto = team.ToModel();
            await _TeamRepository.AddTeam(teamDto);
        }

        public async Task DeleteTeam(int id)
        {
            await _TeamRepository.DeleteTeam(id);
        }

        public async Task<Team> GetTeam(int id)
        {
            TeamDto teamdto = await _TeamRepository.GetTeam(id);
            return teamdto.ToEntity();
        }

        public async Task EditTeam(Team team)
        {
            await _TeamRepository.EditTeam(team.ToModel());
        }
    }
}
