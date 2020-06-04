using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DbContext;
using Data.Dtos;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext DBContext;
        public PlayerRepository(AppDbContext dBContext)
        {
            DBContext = dBContext;
        }

        public async Task<List<PlayerDto>> GetAllPlayers(int teamId)
        {
            return await DBContext.Players.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

    }
}
