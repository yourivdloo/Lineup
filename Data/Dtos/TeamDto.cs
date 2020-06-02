using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Enums;

namespace Data.Dtos
{
    public class TeamDto
    {
        [Key] public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }

    }
}
