using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Dtos
{
    public class FormationDto
    {
        [Key] public int id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }

    }
}
