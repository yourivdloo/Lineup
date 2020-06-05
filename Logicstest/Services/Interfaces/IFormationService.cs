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

        Task<List<Player>> GetAllPlayers(int teamId);
    }
}
