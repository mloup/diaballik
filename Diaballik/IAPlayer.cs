using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class IAPlayer : Player
    {
        private IAStrategy iastrat;

        public IAPlayer(string name, string color, Diaballik.IAStrategy strat): base (name, color)
        {
            iastrat = strat;
        }

        ~IAPlayer()
        {
        }

        public IAStrategy IAStrategy
        {
            get => iastrat;
            set
            {
                iastrat = value;
            }
        }
    }
}