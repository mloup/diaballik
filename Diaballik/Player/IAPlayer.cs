using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class IAPlayer : Player
    {
        public IAStrategy IAStrategy { get; set; }

        public IAPlayer(string name, string color, Diaballik.IAStrategy strat): base (name, color)
        {
            IAStrategy = strat;
        }

        ~IAPlayer()
        {
        }
    }
}