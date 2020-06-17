using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Logics.Entities;
using Data.Enums;

namespace Lineup.ViewModels
{
    public class FormationViewModel
    {
        [Required (ErrorMessage ="You need to fill in a team name.")]
        public string Name { get; set; }

        public int Id { get; set; }

        public int TeamId { get; set; }

        public List<PlayerPosition> PlayerPositions { get; set; }

        public List<Player> Players { get; set; }

        public List<Position> Positions { get; set; }
    }
}
