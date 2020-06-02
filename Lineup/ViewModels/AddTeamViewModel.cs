using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lineup.ViewModels
{
    public class AddTeamViewModel
    {
       [Required]
        public string TeamName { get; set; }
    }
}
