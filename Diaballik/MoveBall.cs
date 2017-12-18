﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class MoveBall : Command
    {
        private Piece nP;
        private Piece pP;

        public MoveBall(Diaballik.Piece piecePrec, Piece pieceNex)
        {
            throw new System.NotImplementedException();
        }

        ~MoveBall()
        {
            throw new System.NotImplementedException();
        }

        public Piece PrevPiece
        {
            get => pP;
            set
            {
                pP = value;
            }
        }

        public Piece NextPiece
        {
            get => nP;
            set
            {
                nP = value;
            }
        }

        public override void Do()
        {

        }

        public override bool CanDo()
        {
            return false;
        }

        public override void Redo()
        {

        }

        public override void Undo()
        {

        }
    }
}