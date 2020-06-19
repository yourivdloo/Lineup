using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lineup.ViewModels
{
    public class TeamViewModel
    {
        [Required(ErrorMessage = "You need to fill in a team name.")]
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
