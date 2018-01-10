using Diaballik.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Actions
{
    [Serializable]
    public class MoveBall : Move
    {

        public MoveBall(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
        }


        public override void Do(Game g)
        {
            this.Do(g, PrevX, PrevY, NextX, NextY);
        }

        public override bool CanDo(Game g)
        {
            if (PrevX == -1 && PrevY == -1) return true; // Initialisation du Board
            if (g.MoveBallCount == 1 && PrevX != -1 && PrevY != -1) return false;
            TileTypes tile = g.Board.Tiles[PrevX, PrevY];
            bool okay = true;
            if (NextX == PrevX) // déplacement en colonne
            {
                for (int i = Math.Min(PrevY, NextY) + 1; i < Math.Max(PrevY, NextY); i++)
                {
                    if (g.Board.Tiles[NextX, i] != TileTypes.Default) okay = false;
                }
            }
            else if (NextY == PrevY) // déplacement en ligne
            {
                for (int i = Math.Min(PrevX, NextX) + 1; i < Math.Max(PrevX, NextX); i++)
                {
                    if (g.Board.Tiles[i, NextY] != TileTypes.Default) okay = false;
                }
            }
            else if (PrevY < NextY && PrevX < NextX) // diagonale BasDroite
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (g.Board.Tiles[PrevX + i, PrevY + i] != TileTypes.Default) okay = false;
                }

            }
            else if (PrevY > NextY && PrevX > NextX) // diagonale HautGauche
            {
                for (int i = 1; i < PrevY - NextY; i++)
                {
                    if (g.Board.Tiles[PrevX - i, PrevY - i] != TileTypes.Default) okay = false;
                }
            }
            else if (PrevY < NextY && PrevX > NextX) // diagonale BasGauche
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (g.Board.Tiles[PrevX - i, PrevY + i] != TileTypes.Default) okay = false;
                }
            }
            else if (PrevY > NextY && PrevX < NextX) // diagonale HautDroit
            {
                for (int i = 1; i < NextX - PrevX; i++)
                {
                    if (g.Board.Tiles[PrevX + i, PrevY - i] != TileTypes.Default) okay = false;
                }
            }

            switch (tile) // Chelou ?
            {
                case TileTypes.BallPlayer0:
                    if (g.Board.Tiles[NextX, NextY] == TileTypes.PiecePlayer0)
                    {
                        if (okay) return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case TileTypes.BallPlayer1:
                    if (g.Board.Tiles[NextX, NextY] == TileTypes.PiecePlayer1)
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


        //TODO
        public override bool CanUndo(Game g)
        {
            if (g.MoveBallCount == 1) return false;
            TileTypes tile = g.Board.Tiles[PrevX, PrevY];
            bool okay = true;
            if (NextX == PrevX) // déplacement en colonne
            {
                for (int i = Math.Min(PrevY, NextY) + 1; i < Math.Max(PrevY, NextY); i++)
                {
                    if (g.Board.Tiles[NextX, i] != TileTypes.Default) okay = false;
                }
            }
            else if (NextY == PrevY) // déplacement en ligne
            {
                for (int i = Math.Min(PrevX, NextX) + 1; i < Math.Max(PrevX, NextX); i++)
                {
                    if (g.Board.Tiles[i, NextY] != TileTypes.Default) okay = false;
                }
            }
            else if (PrevY < NextY && PrevX < NextX) // diagonale BasDroite
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (g.Board.Tiles[PrevX + i, PrevY + i] != TileTypes.Default) okay = false;
                }

            }
            else if (PrevY > NextY && PrevX > NextX) // diagonale HautGauche
            {
                for (int i = 1; i < PrevY - NextY; i++)
                {
                    if (g.Board.Tiles[PrevX - i, PrevY - i] != TileTypes.Default) okay = false;
                }
            }
            else if (PrevY < NextY && PrevX > NextX) // diagonale BasGauche
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (g.Board.Tiles[PrevX - i, PrevY + i] != TileTypes.Default) okay = false;
                }
            }
            else if (PrevY > NextY && PrevX < NextX) // diagonale HautDroit
            {
                for (int i = 1; i < NextX - PrevX; i++)
                {
                    if (g.Board.Tiles[PrevX + i, PrevY - i] != TileTypes.Default) okay = false;
                }
            }

            switch (tile) // Chelou ?
            {
                case TileTypes.BallPlayer0:
                    if (g.Board.Tiles[NextX, NextY] == TileTypes.PiecePlayer0)
                    {
                        if (okay) return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case TileTypes.BallPlayer1:
                    if (g.Board.Tiles[NextX, NextY] == TileTypes.PiecePlayer1)
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

        public override void Undo(Game g)
        {
            this.Do(g, NextX, NextY, PrevX, PrevY);
        }

        private void Do(Game g, int prevX, int prevY, int nextX, int nextY)
        {
            g.Board.MoveBall(prevX, prevY, nextX, nextY);
        }
    }
}