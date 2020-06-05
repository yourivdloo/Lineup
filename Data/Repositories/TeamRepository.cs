using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositories.Interfaces;
using Data.Dtos;
using System.Threading.Tasks;
using Data.DbContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Enums;

namespace Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext DBContext;

        private bool AutoSaveChanges { get; } = true;

        public TeamRepository(AppDbContext dBContext)
        {
            DBContext = dBContext;
        }

        public async Task<List<TeamDto>> GetAllTeams(Guid userId)
        {
            return await DBContext.Teams.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task AddTeam(TeamDto teamDto)
        {
            DBContext.Teams.Add(teamDto);
            await AutoSaveChangesAsync();
        }

        public virtual async Task<int> SaveAllChangesAsync()
        {
            return await DBContext.SaveChangesAsync();
        }



        private async Task<int> AutoSaveChangesAsync()
        {
            return AutoSaveChanges ? await DBContext.SaveChangesAsync() : (int)SavedStatus.WillBeSavedExplicitly;
        }

        public async Task DeleteTeam(int teamId)
        {
            TeamDto teamDto = await GetTeam(teamId);
            DBContext.Remove(teamDto);
            await AutoSaveChangesAsync();
        }

        public async Task<TeamDto> GetTeam(int teamId)
        {
            return await DBContext.Teams.AsNoTracking().Where(x => x.Id == teamId).FirstOrDefaultAsync();
        }

        public async Task<List<PlayerDto>> GetAllPlayers(int teamId)
        {
            return await DBContext.Players.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

        public async Task<List<FormationDto>> GetAllFormations(int teamId)
        {
            return await DBContext.Formations.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

    }
}
