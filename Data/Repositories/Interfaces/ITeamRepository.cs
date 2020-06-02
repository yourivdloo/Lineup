using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Dtos;

namespace Data.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<TeamDto>> GetTeams(Guid userId);

        Task AddTeam();
    }
}
