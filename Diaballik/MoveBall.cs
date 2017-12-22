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
            Tiles tile = Game.INSTANCE.Board.Tiles[nextX, nextY];
            Game.INSTANCE.Board.Tiles[nextX, nextY] = Game.INSTANCE.Board.Tiles[prevX, prevY];
            Game.INSTANCE.Board.Tiles[prevX, prevY] = tile;
        }

        public override bool CanDo()
        {
            Tiles tile = Game.INSTANCE.Board.Tiles[prevX, prevY];
            bool okay = true;
            if (nextX == prevX)
            {
                for(int i = Math.Min(prevY, nextY)+1; i< Math.Max(prevY, nextY); i++)
                {
                    if (!(Game.INSTANCE.Board.Tiles[nextX, i] == Tiles.Default)) okay = false;
                }
            }else if(nextY == prevY)
            {
                for (int i = Math.Min(prevX, nextX) + 1; i < Math.Max(prevX, nextX); i++)
                {
                    if (!(Game.INSTANCE.Board.Tiles[i, nextY] == Tiles.Default)) okay = false;
                }
            }
            else if(prevY < nextY && prevX < nextX)
            {
                for (int i = 1; i < nextY - prevY; i++)
                {
                    if (!(Game.INSTANCE.Board.Tiles[prevX + i, prevY + i] == Tiles.Default)) okay = false;
                }

            }
            else if(prevY > nextY && prevX > nextX)
            {
                for (int i = 1; i < prevY - nextY; i++)
                {
                    if (!(Game.INSTANCE.Board.Tiles[prevX - i, prevY - i] == Tiles.Default)) okay = false;
                }
            }
            else if(prevY < nextY && prevX > nextX)
            {
                for (int i = 1; i < nextY - prevY; i++)
                {
                    if (!(Game.INSTANCE.Board.Tiles[prevX - i, prevY + i] == Tiles.Default)) okay = false;
                }
            }
            else if(prevY > nextY && prevX < nextX)
            {
                for (int i = 1; i < nextX - prevX; i++)
                {
                    if (!(Game.INSTANCE.Board.Tiles[prevX + i, prevY - i] == Tiles.Default)) okay = false;
                }
            }


            switch (tile)
            {
                case Tiles.BallPlayer0:
                    if(Game.INSTANCE.Board.Tiles[nextX, nextY] == Tiles.PiecePlayer0)
                    {
                        if (okay) return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Tiles.BallPlayer1:
                    if (Game.INSTANCE.Board.Tiles[nextX, nextY] == Tiles.PiecePlayer1)
                    {
                        if (okay) return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                default: return false;


            }
            return false;
            
        }

        public override void Redo()
        {
            Do();
        }

        public override void Undo()
        {
            Tiles tile = Game.INSTANCE.Board.Tiles[nextX, nextY];
            Game.INSTANCE.Board.Tiles[nextX, nextY] = Game.INSTANCE.Board.Tiles[prevX, prevY];
            Game.INSTANCE.Board.Tiles[prevX, prevY] = tile;
        }
    }
}