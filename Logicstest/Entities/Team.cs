using System;
using System.Collections.Generic;
using System.Text;

namespace Logics.Classes
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Formation> Formations { get; set; }
    }
}
