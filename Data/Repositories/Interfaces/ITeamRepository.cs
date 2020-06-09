using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Dtos;

namespace Data.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<TeamDto>> GetAllTeams(Guid userId);

        Task AddTeam(TeamDto teamDto);

        Task DeleteTeam(int teamId);

        Task<TeamDto> GetTeam(int teamId);

        Task EditTeam(TeamDto teamDto);

        Task<List<PlayerDto>> GetAllPlayers(int teamId);

        Task<List<FormationDto>> GetAllFormations(int teamId);
    }
}
