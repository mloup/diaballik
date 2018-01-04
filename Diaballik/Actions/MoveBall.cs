using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    [Serializable]
    public class MoveBall : Command
    {
        Board _Board;

        public MoveBall(int x1, int y1, int x2, int y2, Board b)
        {
            PrevX = x1;
            PrevY = y1;
            NextX = x2;
            NextY = y2;
            _Board = b;
        }

        ~MoveBall()
        {
        }

        public override void Do()
        {
            if (PrevX == -1 && PrevY == -1)
            {
                _Board.Tiles[NextX, NextY] = (NextX == 0) ? Tiles.BallPlayer0 : Tiles.BallPlayer1;
            }
            else
            {
                _Board.Tiles[NextX, NextY] = _Board.Tiles[PrevX, PrevY];
                if (_Board.Tiles[NextX, NextY] == Tiles.BallPlayer0) _Board.Tiles[PrevX, PrevY] = Tiles.PiecePlayer0;
                if (_Board.Tiles[NextX, NextY] == Tiles.BallPlayer1) _Board.Tiles[PrevX, PrevY] = Tiles.PiecePlayer1;

            }
        }

        public override bool CanDo()
        {
            if (PrevX == -1 && PrevY == -1) return true; // Initialisation du Board
            Tiles tile = _Board.Tiles[PrevX, PrevY];
            bool okay = true;
            if (NextX == PrevX) // déplacement en colonne
            {
                for(int i = Math.Min(PrevY, NextY)+1; i< Math.Max(PrevY, NextY); i++)
                {
                    if (_Board.Tiles[NextX, i] != Tiles.Default) okay = false;
                }
            }else if(NextY == PrevY) // déplacement en ligne
            {
                for (int i = Math.Min(PrevX, NextX) + 1; i < Math.Max(PrevX, NextX); i++)
                {
                    if (_Board.Tiles[i, NextY] != Tiles.Default) okay = false;
                }
            }
            else if(PrevY < NextY && PrevX < NextX) // diagonale BasDroite
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (_Board.Tiles[PrevX + i, PrevY + i] != Tiles.Default) okay = false;
                }

            }
            else if(PrevY > NextY && PrevX > NextX) // diagonale HautGauche
            {
                for (int i = 1; i < PrevY - NextY; i++)
                {
                    if (_Board.Tiles[PrevX - i, PrevY - i] != Tiles.Default) okay = false;
                }
            }
            else if(PrevY < NextY && PrevX > NextX) // diagonale BasGauche
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (_Board.Tiles[PrevX - i, PrevY + i] != Tiles.Default) okay = false;
                }
            }
            else if(PrevY > NextY && PrevX < NextX) // diagonale HautDroit
            {
                for (int i = 1; i < NextX - PrevX; i++)
                {
                    if (_Board.Tiles[PrevX + i, PrevY - i] != Tiles.Default) okay = false;
                }
            }


            switch (tile) // Chelou ?
            {
                case Tiles.BallPlayer0:
                    if(_Board.Tiles[NextX, NextY] == Tiles.PiecePlayer0)
                    {
                        if (okay) return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Tiles.BallPlayer1:
                    if (_Board.Tiles[NextX, NextY] == Tiles.PiecePlayer1)
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

        public override void Undo()
        {
            int prevXTemp = PrevX;
            int prevYTemp = PrevY;
            PrevX = NextX;
            PrevY = NextY;
            NextX = prevXTemp;
            NextY = prevYTemp;
            this.Do();
        }
    }
}