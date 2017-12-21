using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class SelectPiece : Command
    {
        private Piece piece;

        ~SelectPiece()
        {
            throw new System.NotImplementedException();
        }

        public Piece SelectedPiece
        {
            get => piece;
            set
            {
                piece = value;
            }
        }

        public override bool CanDo()
        {
            return false;
        }

        public override void Do()
        {

        }

        public override void Redo()
        {

        }

        public override void Undo()
        {

        }

        public SelectPiece(Diaballik.Piece piecePrec, Piece pieceNex)
        {
            throw new System.NotImplementedException();
        }
    }
}