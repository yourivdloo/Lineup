using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Enums;

namespace Data.Dtos
{
    public class PlayerPositionDto
    {
        [Key] public int id { get; set; }
        public int FormationId { get; set; }
        public int PlayerId { get; set; }
        public Position position { get; set; }

    }
}
