using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    class PC
    {
        //Score
        public int kills, deaths, points;

        //Ships controlled by this player
        public List<Ship> fleet; //

        //Any custom controls or camera settings

        //Default Constructor
        public PC()
        {
            kills = 0; deaths = 0; points = 0;
        }
    }
}