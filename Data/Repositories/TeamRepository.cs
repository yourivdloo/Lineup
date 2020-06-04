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
        private readonly AppDbContext dBContext;

        private bool AutoSaveChanges { get; } = true;

        public TeamRepository(AppDbContext dbContext)
        {
            dBContext = dbContext;
        }

        public async Task<List<TeamDto>> GetAllTeams(Guid userId)
        {
            return await dBContext.Teams.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task AddTeam(TeamDto teamDto)
        {
            dBContext.Teams.Add(teamDto);
            await AutoSaveChangesAsync();
        }

        public virtual async Task<int> SaveAllChangesAsync()
        {
            return await dBContext.SaveChangesAsync();
        }



        private async Task<int> AutoSaveChangesAsync()
        {
            return AutoSaveChanges ? await dBContext.SaveChangesAsync() : (int)SavedStatus.WillBeSavedExplicitly;
        }

        public async Task DeleteTeam(int teamId)
        {
            TeamDto teamDto = await GetTeam(teamId);
            dBContext.Remove(teamDto);
            await AutoSaveChangesAsync();
        }

        public async Task<TeamDto> GetTeam(int teamId)
        {
            return await dBContext.Teams.AsNoTracking().Where(x => x.Id == teamId).FirstOrDefaultAsync();
        }

        public async Task<List<PlayerDto>> GetAllPlayers(int teamId)
        {
            return await dBContext.Players.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

        public async Task<List<FormationDto>> GetAllFormations(int teamId)
        {
            return await dBContext.Formations.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

    }
}
