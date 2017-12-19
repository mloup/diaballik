using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class IAPlayer : Player
    {
        private IAStrategy iastrat;
        private int wichpiecehasball;

        public IAPlayer(string name, string color, int nBTiles, Diaballik.IAStrategy strat): base (name, color, 2, nBTiles)
        {
            throw new System.NotImplementedException();
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

        public int wichPieceHasBall
        {
            get => wichpiecehasball;
            set
            {
                wichpiecehasball = value;
            }
        }
    }
}