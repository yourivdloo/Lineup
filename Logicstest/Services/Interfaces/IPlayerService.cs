using Logics.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAllPlayers(int teamId);

        Task AddPlayer(Player player);

        Task DeletePlayer(int Id);
    }
}
