using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class MoveBall : Command
    {
        private int nX;
        private int nY;
        private int pX;
        private int pY;

        public MoveBall(int x1, int y1, int x2, int y2)
        {
            prevX = x1;
            prevY = y1;
            nextX = x2;
            nextY = y2;
        }

        ~MoveBall()
        {
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



        public override void Do()
        {

        }

        public override bool CanDo()
        {
            if (Game.INSTANCE.Board.Tiles[nextX, nextY] == Tiles.Default)
            {
                if ((Math.Abs(nextX - prevX) == 1 && prevY == nextX) || (Math.Abs(nextY - prevY) == 1 && prevX == nextX))
                {
                    return true;
                }
                if (prevX == -1 && prevY == -1)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public override void Redo()
        {
            Do();
        }

        public override void Undo()
        {

        }
    }
}