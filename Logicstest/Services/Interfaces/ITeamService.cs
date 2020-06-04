﻿using Logics.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams(Guid userId);

        Task AddTeam(Team team);

        Task DeleteTeam(int id);
    }
}