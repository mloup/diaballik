using Diaballik.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Actions
{
    [Serializable]
    public class MovePiece : Move
    {
        public MovePiece(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
        }


        public override void Do(Game g)
        {
            this.Do(g, PrevX, PrevY, NextX, NextY);
        }

        public override bool CanDo(Game g)
        {
            bool res = false;
            if (g.MovePieceCount == 2) return false;
            Console.Write("test1" + res + "\n");
            if (g.Board.Tiles[NextX, NextY] == TileTypes.Default)
            {
                Console.Write("test2" + res + "\n");
                if (g.Board.Tiles[PrevX, PrevY] == TileTypes.PiecePlayer0 || g.Board.Tiles[PrevX, PrevY] == TileTypes.PiecePlayer1)
                {
                    Console.Write("test3" + res + "\n");
                    if ((Math.Abs(NextX - PrevX) == 1 && PrevY == NextY) || (Math.Abs(NextY - PrevY) == 1 && PrevX == NextX))
                    {
                        res = true;
                        Console.Write("test4" + res + "\n");
                    }
                }
            }
            Console.Write("test5" + res + "\n");
            return res;
        }

        public override bool CanUndo(Game g)
        {
            bool res = false;
            if (g.MovePieceCount == 0) return false;
            if (g.Board.Tiles[PrevX, PrevY] == TileTypes.Default)
            {
                if (g.Board.Tiles[NextX, NextY] == TileTypes.PiecePlayer0 || g.Board.Tiles[NextX, NextY] == TileTypes.PiecePlayer1)
                {
                    if ((Math.Abs(PrevX - NextX) == 1 && PrevY == NextY) || (Math.Abs(NextY - PrevY) == 1 && PrevX == NextX))
                    {
                        res = true;
                    }
                }
            }
            return res;
        }

        public override void Undo(Game g)
        { 
            this.Do(g , NextX, NextY, PrevX, PrevY);
        }

        private void Do(Game g, int prevX, int prevY, int nextX, int nextY)
        {
            g.Board.MovePiece(prevX, prevY, nextX, nextY);
        }
    }
}