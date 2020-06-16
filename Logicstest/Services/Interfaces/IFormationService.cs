using Logics.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Services.Interfaces
{
    public interface IFormationService
    {
        Task<List<Formation>> GetAllFormations(int teamId);

        Task<int> AddFormation(Formation formation);

        Task AddPlayerPosition(PlayerPosition pp);

        Task DeleteFormation(int formationId);

        Task EditFormation(Formation formation);

        Task EditPlayerPosition(PlayerPosition pp);

        Task<List<PlayerPosition>> GetAllPlayerPositions(int id);

        Task<Formation> GetFormation(int id);
    }
}
