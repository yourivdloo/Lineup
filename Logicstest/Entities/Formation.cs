using System;
using System.Collections.Generic;
using System.Text;

namespace Logics.Entities
{
    public class Formation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerPosition> Players { get; set; }
    }
}
