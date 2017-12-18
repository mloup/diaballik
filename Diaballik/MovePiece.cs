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
            get => default(int);
            set
            {
            }
        }

        public int prevY
        {
            get => default(int);
            set
            {
            }
        }

        public int nextX
        {
            get => default(int);
            set
            {
            }
        }

        public int nextY
        {
            get => default(int);
            set
            {
            }
        }

        public Piece piece
        {
            get => default(int);
            set
            {
            }
        }
    }
}