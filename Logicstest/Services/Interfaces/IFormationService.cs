using Data.Enums;
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

        Task DeleteFormation(int formationId);

        Task EditFormation(Formation formation);

        Task<Formation> GetFormation(int id);

        Task<List<PlayerPosition>> GetAllPlayerPositions(int id);

        Task<PlayerPosition> GetPlayerPosition(int playerPositionId);

        Task<int> AddPlayerPosition(PlayerPosition pp);

        Task EditPlayerPosition(PlayerPosition pp);

        List<string> CheckFormation(List<Position> positions);
    }
}
