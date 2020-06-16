using System;
using System.Collections.Generic;
using System.Text;
using Logics.Services.Interfaces;
using Data.Repositories.Interfaces;
using System.Threading.Tasks;
using Logics.Entities;
using Lineup.Logics.Mappers;

namespace Logics.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _PlayerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _PlayerRepository = playerRepository;
        }

        public async Task<List<Player>> GetAllPlayers(int teamId)
        {
            var playerDtos = await _PlayerRepository.GetAllPlayers(teamId);
            var players = new List<Player>();
            foreach (var dto in playerDtos)
            {
                players.Add(dto.ToEntity());
            }
            return players;
        }

        public async Task AddPlayer(Player player)
        {
            await _PlayerRepository.AddPlayer(player.ToModel());
        }

        public async Task DeletePlayer(int id)
        {
            await _PlayerRepository.DeletePlayer(id);
        }

        public async Task EditPlayer(Player player)
        {
            await _PlayerRepository.EditPlayer(player.ToModel());
        }

        public async Task<Player> GetPlayer(int id)
        {
            var playerDto = await _PlayerRepository.GetPlayer(id);
            return (playerDto.ToEntity());
        }
    }
}
