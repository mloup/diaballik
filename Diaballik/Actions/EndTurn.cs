using Diaballik;
using System;

namespace Diaballik
{
    [Serializable]
    public class EndTurn : Command
    {
        public int NextPlayer { get; set; }
        public Game _Game { get; set; }

        public EndTurn(Game game)
        {
            _Game = game;
            NextPlayer = (_Game.CurrentPlayer == 1) ? 0 : 1;
        }

        
        public override void Do()
        {
            _Game.CurrentPlayer = NextPlayer;
            _Game.MoveBallCount = 0;
            _Game.MovePieceCount = 0;
        }
        
        public override bool CanDo()
        {
            return (_Game.MoveBallCount + _Game.MovePieceCount >= 1)? true : false; // Un joueur est obligé de faire au moins une action par tour
        }

        
        public override void Undo()
        {
            throw new InvalidOperationException("Impossible d'undo la commande EndTurn");
        }
    }
}

