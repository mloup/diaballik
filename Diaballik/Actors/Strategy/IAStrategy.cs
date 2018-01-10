using Diaballik.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Actors.Strategy
{
    public abstract class IAStrategy
    {

        public IAStrategy()
        {
        }

        public enum EnumCommand
        {
            Default = -1,
            MovePiece = 0,
            MoveBall = 1,
            EndTurn = 2
        };

        /// <summary>
        /// L'IA joue une action, qui peut être de passer son tour
        /// </summary>
        public abstract void PlayOneAction(Game g);
    }
}