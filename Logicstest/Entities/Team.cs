using System;
using System.Collections.Generic;
using System.Text;

namespace Logics.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Formation> Formations { get; set; }
    }
}
