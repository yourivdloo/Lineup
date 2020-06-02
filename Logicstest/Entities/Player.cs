using System;
using System.Collections.Generic;
using System.Text;

namespace Logics.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Preference_one { get; set; }
        public int Preference_two { get; set; }
        public int Preference_three { get; set; }
        public int Priority { get; set; }
    }
}
