using System;
using System.Collections.Generic;
using System.Text;
using Data.Enums;

namespace Logics.Entities
{
    public class PlayerPosition
    {
        public int Id { get; set; }

        public int FormationId { get; set; }

        public Position Position { get; set; }

        public int PlayerId { get; set; }
    }
}
