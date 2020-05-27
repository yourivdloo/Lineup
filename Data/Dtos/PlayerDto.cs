using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Enums;

namespace Data.Dtos
{
    public class PlayerDto
    {
        [Key] public int id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public Position Preference_one { get; set; }
        public Position Preference_two { get; set; }
        public Position Preference_three { get; set; }
        public int Priority { get; set; }

    }
}
