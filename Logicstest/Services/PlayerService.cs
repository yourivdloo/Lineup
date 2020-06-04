using System;
using System.Collections.Generic;
using System.Text;
using Logics.Services.Interfaces;
using Data.Repositories.Interfaces;
using System.Threading.Tasks;
using Logics.Entities;
using Data.Dtos;
using Lineup.Logics.Mappers;

namespace Logics.Services
{
    public class PlayerService
    {
        private readonly IPlayerRepository IPlayerRepository;
        public PlayerService(IPlayerRepository iPlayerRepository)
        {
            IPlayerRepository = iPlayerRepository;
        }

        public async Task<List<Player>> GetAllPlayers(int teamId)
        {
            List<PlayerDto> playerDtos = await IPlayerRepository.GetAllPlayers(teamId);
            List<Player> players = new List<Player>();
            foreach (PlayerDto dto in playerDtos)
            {
                players.Add(dto.ToEntity());
            }
            return players;
        }

    }
}
