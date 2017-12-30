using Diaballik;
using System;

namespace Diaballik
{
    [Serializable]
    public class EndTurn : Command
    {
        public int NextPlayer { get; set; }

        public EndTurn(int nextPl)
        {
            NextPlayer = nextPl;
        }

        
        public override void Do(Game g)
        {
            if (CanDo(g))
            g.EndTurn(NextPlayer);
            g.CommandHistory.Push(new CommandMemento(this));
            g.UndoHistory.Clear();
        }
        
        public override bool CanDo(Game g)
        {
            return true;
        }

        public override void Done()
        {
            throw new NotImplementedException();
        }

        public override void IsDone()
        {
            throw new NotImplementedException();
        }

        
        public override void Redo(Game g)
        {
           
        }

        public override void Undo(Game g)
        {
            throw new InvalidOperationException("Impossible d'undo la commande EndTurn");
        }
    }
}

