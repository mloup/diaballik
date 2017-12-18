using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class MovePiece : Command
    {
        private int nX;
        private int nY;
        private int pX;
        private int pY;
        private Piece p;

        public MovePiece(int x1, int y1, int x2, int y2)
        {
            throw new System.NotImplementedException();
        }

        ~MovePiece()
        {
            throw new System.NotImplementedException();
        }

        public int prevX
        {
            get => pX;
            set
            {
                pX = value;
            }
        }

        public int prevY
        {
            get => pY;
            set
            {
                pY = value;
            }
        }

        public int nextX
        {
            get => nX;
            set
            {
                nX = value;
            }
        }

        public int nextY
        {
            get => nY;
            set
            {
                nY = value;
            }
        }

        public Piece piece
        {
            get => p;
            set
            {
                p = value;
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