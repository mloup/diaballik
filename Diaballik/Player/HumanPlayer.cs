using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, string colour) : base (name, colour)
        {
            Color = colour;
            Name = name;
        }

        ~HumanPlayer()
        {
        }
    }
}