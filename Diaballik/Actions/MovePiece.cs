using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    [Serializable]
    public class MovePiece : Command
    {
        public Board _Board { get; set; }

        public MovePiece(int x1, int y1, int x2, int y2, Board b)
        {
            PrevX = x1;
            PrevY = y1;
            NextX = x2;
            NextY = y2;
            _Board = b;

        }

        ~MovePiece()
        {
        }

        public override void Do()
        {
            if (PrevX == -1 && PrevY == -1) // Initialisation du Board
            {
                _Board.Tiles[NextX, NextY] = (NextX == 0) ? Tiles.PiecePlayer0 : Tiles.PiecePlayer1;
            }
            else
            {
                _Board.Tiles[NextX, NextY] = _Board.Tiles[PrevX, PrevY];
                _Board.Tiles[PrevX, PrevY] = Tiles.Default;
            }
        }

        public override bool CanDo()
        {
            bool res = false;
            if (PrevX == -1 && PrevY == -1) return true; // Initialisation du Board
            if (_Board.Tiles[NextX, NextY]== Tiles.Default)
            {
                if (_Board.Tiles[PrevX, PrevY] == Tiles.PiecePlayer0 || _Board.Tiles[PrevX, PrevY] == Tiles.PiecePlayer1)
                {
                    if ((Math.Abs(NextX - PrevX) == 1 && PrevY == NextY) || (Math.Abs(NextY - PrevY) == 1 && PrevX == NextX))
                    {
                        res = true;
                    }
                }
            }
            return res;
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

        /*public override bool IsDone()
        {
            return (_Board.Tiles[NextX, NextY] == Tiles.PiecePlayer0 ||
                    _Board.Tiles[NextX, NextY] == Tiles.PiecePlayer1) ? true : false;
        }*/
    }
}