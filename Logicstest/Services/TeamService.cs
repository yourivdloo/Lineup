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
        private readonly ITeamRepository ITeamRepository;
        public TeamService(ITeamRepository iTeamRepository)
        {
            ITeamRepository = iTeamRepository;
        }
        
        public async Task<List<Team>> GetAllTeams(Guid userId)
        {
            List<TeamDto> TeamDtos = await ITeamRepository.GetAllTeams(userId);
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
            await ITeamRepository.AddTeam(teamDto);
        }

        public async Task DeleteTeam(int id)
        {
            await ITeamRepository.DeleteTeam(id);
        }
    }
}
