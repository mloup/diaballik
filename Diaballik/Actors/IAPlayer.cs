using Diaballik.Actors.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Actors
{
    [Serializable]
    public class IAPlayer : Player
    {
        public IAStrategy IAStrategy { get; set; }

        public IAPlayer(string name, string color, IAStrategy strat): base (name, color)
        {
            IAStrategy = strat;
        }

        ~IAPlayer()
        {
        }
    }
}