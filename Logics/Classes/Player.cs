using System;
using System.Collections.Generic;
using System.Text;
using Lineup.Data.Enums;

namespace Lineup.Logics.Classes
{
    public class Player
    {

        public string Name { get; set; }
        public Position Preference_one { get; set; }
        public Position Preference_two { get; set; }
        public Position Preference_three { get; set; }
        public int Priority { get; set; }

    }
}
