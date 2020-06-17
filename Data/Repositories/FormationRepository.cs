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
    public class FormationRepository : IFormationRepository 
    {
        private readonly LineupDbContext DBContext;

        public FormationRepository(LineupDbContext dBContext)
        {
            DBContext = dBContext;
        }

        public async Task<List<FormationDto>> GetAllFormations(int teamId)
        {
            return await DBContext.Formations.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

        public async Task<int> AddFormation(FormationDto formationDto)
        {
            DBContext.Formations.Add(formationDto);
            await DBContext.SaveChangesAsync();
            return formationDto.id;
        }

        public async Task<int> AddPlayerPosition(PlayerPositionDto ppDto)
        {
            DBContext.PlayerPositions.Add(ppDto);
            await DBContext.SaveChangesAsync();
            return ppDto.id;
        }

        private async Task DeleteAllPlayerPositions(int id)
        {
            List<PlayerPositionDto> playerPositions = await GetAllPlayerPositions(id);

            foreach (var pp in playerPositions)
            {
                DBContext.PlayerPositions.Remove(pp);
            }
            await DBContext.SaveChangesAsync();
        }

        public async Task<List<PlayerPositionDto>> GetAllPlayerPositions(int id)
        {
            return await DBContext.PlayerPositions.AsNoTracking().Where(x => x.FormationId == id).ToListAsync();
        }

        public async Task DeleteFormation(int id)
        {
            await DeleteAllPlayerPositions(id);

            FormationDto formationDto = await GetFormation(id);
            DBContext.Formations.Remove(formationDto);
            await DBContext.SaveChangesAsync();
        }

        public async Task<FormationDto> GetFormation(int id)
        {
            return await DBContext.Formations.AsNoTracking().Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<PlayerPositionDto> GetPlayerPosition(int playerPositionId)
        {
            return await DBContext.PlayerPositions.AsNoTracking().Where(x => x.id == playerPositionId).FirstOrDefaultAsync();
        }

        public async Task EditFormation(FormationDto formationDto)
        {
            DBContext.Formations.Update(formationDto);
            await DBContext.SaveChangesAsync();
        }

        public async Task EditPlayerPosition(PlayerPositionDto ppDto)
        {
            DBContext.PlayerPositions.Update(ppDto);
            await DBContext.SaveChangesAsync();
        }
    }
}
