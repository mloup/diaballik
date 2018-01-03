using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    [Serializable]
    public class MoveBall : Command
    {
        public MoveBall(int x1, int y1, int x2, int y2)
        {
            PrevX = x1;
            PrevY = y1;
            NextX = x2;
            NextY = y2;
        }

        ~MoveBall()
        {
        }

        public override void Do(Game g)
        {
            if (CanDo(g))
            {
                g.MoveBall(PrevX, PrevY, NextX, NextY);
                g.CommandHistory.Push(new CommandMemento(this));
                g.UndoHistory.Clear();
            }
        }

        public override bool CanDo(Game g)
        {
            if (PrevX == -1 && PrevY == -1) return true; // Initialisation du Board
            if (g.MoveBallCount == 1) return false; // On ne peut bouger qu'une seule fois la balle par tour
            Tiles tile = g.Board.Tiles[PrevX, PrevY];
            bool okay = true;
            if (NextX == PrevX)
            {
                for(int i = Math.Min(PrevY, NextY)+1; i< Math.Max(PrevY, NextY); i++)
                {
                    if (!(g.Board.Tiles[NextX, i] == Tiles.Default)) okay = false;
                }
            }else if(NextY == PrevY)
            {
                for (int i = Math.Min(PrevX, NextX) + 1; i < Math.Max(PrevX, NextX); i++)
                {
                    if (!(g.Board.Tiles[i, NextY] == Tiles.Default)) okay = false;
                }
            }
            else if(PrevY < NextY && PrevX < NextX)
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (!(g.Board.Tiles[PrevX + i, PrevY + i] == Tiles.Default)) okay = false;
                }

            }
            else if(PrevY > NextY && PrevX > NextX)
            {
                for (int i = 1; i < PrevY - NextY; i++)
                {
                    if (!(g.Board.Tiles[PrevX - i, PrevY - i] == Tiles.Default)) okay = false;
                }
            }
            else if(PrevY < NextY && PrevX > NextX)
            {
                for (int i = 1; i < NextY - PrevY; i++)
                {
                    if (!(g.Board.Tiles[PrevX - i, PrevY + i] == Tiles.Default)) okay = false;
                }
            }
            else if(PrevY > NextY && PrevX < NextX)
            {
                for (int i = 1; i < NextX - PrevX; i++)
                {
                    if (!(g.Board.Tiles[PrevX + i, PrevY - i] == Tiles.Default)) okay = false;
                }
            }


            switch (tile)
            {
                case Tiles.BallPlayer0:
                    if(g.Board.Tiles[NextX, NextY] == Tiles.PiecePlayer0)
                    {
                        if (okay) return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Tiles.BallPlayer1:
                    if (g.Board.Tiles[NextX, NextY] == Tiles.PiecePlayer1)
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

        public override void Redo(Game g)
        {
            Command cmd = g.UndoHistory.Pop().GetCommand();
            if (cmd.CanDo(g) && cmd is MoveBall)
            {
                cmd.Do(g);
            }
            else
            {
                throw new ArgumentException("La dernière commande undo n'est pas de type MoveBall");
            }
        }

        public override void Undo(Game g)
        {
            Command UndoLastCmd = g.CommandHistory.Pop().GetCommand();
            if (UndoLastCmd is MoveBall)
            {
                g.MoveBall(UndoLastCmd.NextX, UndoLastCmd.NextY, UndoLastCmd.PrevX, UndoLastCmd.PrevY);
                g.UndoHistory.Push(new CommandMemento(UndoLastCmd));
            }
            else
            {
                throw new ArgumentException("La dernière commande n'est pas de type MoveBall");
            }
        }

        public override void Done()
        {
            throw new NotImplementedException();
        }

        public override void IsDone()
        {
            throw new NotImplementedException();
        }
    }
}