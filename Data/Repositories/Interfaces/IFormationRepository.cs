using Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IFormationRepository
    {
        Task<List<FormationDto>> GetAllFormations(int teamId);

        Task<int> AddFormation(FormationDto formationDto);

        Task AddPlayerPosition(PlayerPositionDto ppDto);

        Task DeleteAllPlayerPositions(int id);

        Task<List<PlayerPositionDto>> GetAllPlayerPositions(int id);

        Task DeleteFormation(int id);

        Task<FormationDto> GetFormation(int id);

        Task EditFormation(FormationDto formationDto);

        Task EditPlayerPosition(PlayerPositionDto ppDto);

    }
}
