﻿using System;
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
        private readonly LineupDbContext DBContext;

        public TeamRepository(LineupDbContext dBContext)
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
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteTeam(int id)
        {
            TeamDto teamDto = await GetTeam(id);
            DBContext.Remove(teamDto);
            await DBContext.SaveChangesAsync();
        }

        public async Task<TeamDto> GetTeam(int teamId)
        {
            return await DBContext.Teams.AsNoTracking().Where(x => x.Id == teamId).FirstOrDefaultAsync();
        }

        public async Task EditTeam(TeamDto teamDto)
        {
            DBContext.Teams.Update(teamDto);
            await DBContext.SaveChangesAsync();
        }
    }
}
