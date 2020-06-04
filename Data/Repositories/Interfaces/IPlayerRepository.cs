using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<PlayerDto>> GetAllPlayers(int teamId);

    }
}
