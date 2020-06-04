using Logics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lineup.ViewModels
{
    public class TeamViewModel
    {
        public string Name { get; set; }

        public List<Player> Players { get; set; }

        public List<Formation> Formations { get; set; }
    }
}
