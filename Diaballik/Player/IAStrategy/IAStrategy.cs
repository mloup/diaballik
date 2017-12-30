﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class IAStrategy
    {
        public IntPtr AlgoPtr { get; set; }
        public bool Disposed { get; set; }

        public enum EnumCommand
        {
            Default = 0,
            MovePiece = 1,
            MoveBall = 2,
            EndTurn = 3
        };

        /// <summary>
        /// L'IA joue une action, qui peut être de passer son tour
        /// </summary>
        public abstract void PlayOneAction(Game g);
    }
}