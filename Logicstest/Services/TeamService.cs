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
        
        public async Task<List<Team>> GetTeams(Guid userId)
        {
            List<TeamDto> TeamDtos = await ITeamRepository.GetTeams(userId);
            List<Team> Teams = TeamDtos.ToEntity();
            return Teams;
        }

        public async Task AddTeam()
        {
            await ITeamRepository.AddTeam();
        }
    }
}
