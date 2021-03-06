﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DbContext;
using Data.Dtos;
using Data.Enums;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly LineupDbContext DBContext;

        public PlayerRepository(LineupDbContext dBContext)
        {
            DBContext = dBContext;
        }

        public async Task<List<PlayerDto>> GetAllPlayers(int teamId)
        {
            return await DBContext.Players.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

        public async Task AddPlayer(PlayerDto playerDto)
        {
            DBContext.Players.Add(playerDto);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeletePlayer(int id)
        {
            PlayerDto playerDto = await GetPlayer(id);
            DBContext.Remove(playerDto);
            await DBContext.SaveChangesAsync();
        }

        public async Task<PlayerDto> GetPlayer(int id)
        {
            return await DBContext.Players.AsNoTracking().Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task EditPlayer(PlayerDto playerDto)
        {
            DBContext.Players.Update(playerDto);
            await DBContext.SaveChangesAsync();
        }
    }
}
