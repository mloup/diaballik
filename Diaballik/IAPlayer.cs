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

        public IAPlayer(string name, string color, Diaballik.IAStrategy strat)
        {
            throw new System.NotImplementedException();
        }

        ~IAPlayer()
        {
            throw new System.NotImplementedException();
        }

        public IAStrategy IAStrategy
        {
            get => default(IAStrategy);
            set
            {
            }
        }

        public int wichPieceHasBall
        {
            get => default(int);
            set
            {
            }
        }
    }
}