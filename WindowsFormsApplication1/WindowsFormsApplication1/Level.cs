using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    class Level
    {
        public readonly int Id;
        public readonly string Map;

        public Level(int id, string map)
        {
            Id = id;
            Map = map;
        }
    }
}
