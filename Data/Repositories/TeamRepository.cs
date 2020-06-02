using System;
using System.Collections.Generic;
using System.Text;
using Data.Repositories.Interfaces;
using Data.Dtos;
using System.Threading.Tasks;
using Data.DbContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext dBContext;

        public TeamRepository(AppDbContext dbContext)
        {
            dBContext = dbContext;
        }

        public async Task<List<TeamDto>> GetTeams(Guid userId)
        {
            return await dBContext.Teams.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task AddTeam()
        {
            //await
        }
    }
}
