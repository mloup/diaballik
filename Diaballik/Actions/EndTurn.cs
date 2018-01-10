using Diaballik;
using Diaballik.Engine;
using System;

namespace Diaballik
{
    [Serializable]
    public class EndTurn : Command
    {

        public EndTurn()
        {
        }

        
        public override void Do(Game g)
        {
            g.CurrentPlayer = (g.CurrentPlayer == 1) ? 0 : 1;
            g.MoveBallCount = 0;
            g.MovePieceCount = 0;
        }
        
        public override bool CanDo(Game g)
        {
            return (g.MoveBallCount + g.MovePieceCount >= 1)? true : false; // Un joueur est obligé de faire au moins une action par tour
        }

        
        public override void Undo(Game g)
        {
            throw new InvalidOperationException("Impossible d'undo la commande EndTurn");
        }

        public override bool CanUndo(Game g)
        {
            return false;
        }
    }
}

