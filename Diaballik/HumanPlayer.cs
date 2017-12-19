using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, string colour, int nJoueur, int nBTiles) : base (name, colour, nJoueur, nBTiles)
        {
        }

        ~HumanPlayer()
        {
        }
    }
}