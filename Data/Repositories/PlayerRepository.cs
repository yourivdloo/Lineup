using System;
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
        private readonly AppDbContext DBContext;
        private bool AutoSaveChanges { get; } = true;

        public PlayerRepository(AppDbContext dBContext)
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
            await AutoSaveChangesAsync();
        }

        private async Task<int> AutoSaveChangesAsync()
        {
            return AutoSaveChanges ? await DBContext.SaveChangesAsync() : (int)SavedStatus.WillBeSavedExplicitly;
        }

        public async Task DeletePlayer(int Id)
        {
            PlayerDto playerDto = await GetPlayer(Id);
            DBContext.Remove(playerDto);
            await AutoSaveChangesAsync();
        }

        public async Task<PlayerDto> GetPlayer(int id)
        {
                return await DBContext.Players.AsNoTracking().Where(x => x.id == id).FirstOrDefaultAsync();
        }
    }
}
