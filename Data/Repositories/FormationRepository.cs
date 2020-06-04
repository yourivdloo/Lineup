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
    public class FormationRepository : IFormationRepository 
    {
        private readonly AppDbContext DBContext;
        public FormationRepository(AppDbContext dBContext)
        {
            DBContext = dBContext;
        }

        public async Task<List<FormationDto>> GetAllFormations(int teamId)
        {
            return await DBContext.Formations.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }
    }
}
