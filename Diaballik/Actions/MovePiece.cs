using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    [Serializable]
    public class MovePiece : Command
    {
        public MovePiece(int x1, int y1, int x2, int y2)
        {
            PrevX = x1;
            PrevY = y1;
            NextX = x2;
            NextY = y2;
        }

        ~MovePiece()
        {
        }

        public override void Do(Game g)
        {
            if (CanDo(g))
            {
                g.MovePiece(PrevX, PrevY, NextX, NextY);
                g.CommandHistory.Push(new CommandMemento(this));
                g.UndoHistory.Clear();
            }
        }

        public override bool CanDo(Game g)
        {
            if (PrevX == -1 && PrevY == -1) return true; // Initialisation du Board
            if (g.Board.Tiles[NextX, NextY]== Tiles.Default)
            {
                if ((Math.Abs(NextX-PrevX)==1 && PrevY == NextY)||(Math.Abs(NextY-PrevY)==1 && PrevX == NextX))
                {
                    return true;
                }
                if (PrevX == -1 && PrevY == -1)
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

        public override void Redo(Game g)
        {
            Command cmd = g.UndoHistory.Pop().GetCommand();
            if (cmd.CanDo(g) && cmd is MovePiece)
            {
                cmd.Do(g);
            }
        }

        public override void Undo(Game g)
        {
            Command UndoLastCmd = g.CommandHistory.Pop().GetCommand();
            if (UndoLastCmd is MovePiece)
            {
                g.MovePiece(UndoLastCmd.NextX, UndoLastCmd.NextY, UndoLastCmd.PrevX, UndoLastCmd.PrevY);
                g.UndoHistory.Push(new CommandMemento(UndoLastCmd));
            }
            else
            {
                throw new ArgumentException("La dernière commande n'est pas de type MovePiece");
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