using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Logics.Entities;

namespace Lineup.ViewModels
{
    public class AddFormationViewModel
    {
        [Required]
        public string Name { get; set; }

        public List<PlayerPosition> PlayerPositions { get; set; }

        public List<Player> Players { get; set; }
    }
}
