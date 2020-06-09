using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lineup.ViewModels
{
    public class PlayerViewModel
    {
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public int PlayerId { get; set; }

        public int TeamId { get; set; }
    }
}
