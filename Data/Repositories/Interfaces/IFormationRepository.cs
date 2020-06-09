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

    }
}
