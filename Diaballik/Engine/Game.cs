using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    [Serializable]
    public class Game
    {
        public Stack<CommandMemento> CommandHistory { get; set; }
        public Stack<CommandMemento> UndoHistory { get; set; }
        public Diaballik.Player[] Players { get; set; }
        public int MovePieceCount { get; set; }
        public int MoveBallCount { get; set; }
        public int CurrentPlayer { get; set; }
        public bool Finished { get; set; }
        public bool GameHasIA { get; set; }
        public Board Board { get; set; }

        public Game()
        {
            Players = new Player[2];
            CommandHistory = new Stack<CommandMemento>();
            UndoHistory = new Stack<CommandMemento>();
            MoveBallCount = 0;
            MovePieceCount = 0;
            Finished = false;
            CurrentPlayer = new Random().Next(0, 2);
        }

        ~Game()
        {
            
        }

        /// <summary>
        /// Après chaque action, test si le compteur est égale à trois, s'il est égal à trois, c'est la fin du tour
        /// </summary>
        public Boolean IsEndTurn()
        {
            return (MoveBallCount + MovePieceCount >= 3);
        }

        /// <summary>
        /// Test le plateau pour regarder si un des joueurs a gagné
        /// </summary>
        public bool IsWin()
        {
            bool res = false;
            for (int i = 0; i < Board.BoardSize; i++)
            {
                if (Board.Tiles[0, i] == Tiles.BallPlayer1)
                {
                    res = true;
                }
            }
            for (int i = 0; i < Board.BoardSize; i++)
            {
                if (Board.Tiles[Board.BoardSize - 1, i] == Tiles.BallPlayer0)
                {
                    res = true;
                }
            }

            return res;
        }

        /// <summary>
        /// Passe au tour suivant lors du visionnage d'une partie
        /// </summary>
        public void NextMove()
        {
            throw new System.NotImplementedException();
            //Command cmd = CommandHistory;
        }

        /// <summary>
        /// Passe au tour précédent lors du visionnage d'une partie
        /// </summary>
        public void PrevMove()
        {
            throw new System.NotImplementedException();
        }

        public void EndTurn()
        {
            Command endTurnCmd = new EndTurn(this);
            if (endTurnCmd.CanDo())
            {
                endTurnCmd.Do();
                CommandHistory.Push(new CommandMemento(endTurnCmd));
            }
        }

        public void MovePiece(int x1, int y1, int x2, int y2)
        {
            if (MovePieceCount >= 2 && x1 != -1 && x2 != -1) throw new InvalidOperationException("Seulement 2 actions MovePiece autorisées par tour "); 
            MovePiece mp = new MovePiece(x1, y1, x2, y2, this.Board);
            if (mp.CanDo())
            {
                mp.Do();
                MovePieceCount++;
                CommandHistory.Push(new CommandMemento(mp));
                UndoHistory.Clear();

                Board.PrintBoard();

                if (MovePieceCount + MoveBallCount == 3 && x1 != -1 && x2 != -1)
                {
                    Command endTurn = new EndTurn(this);
                    endTurn.Do();
                }
            }
            else throw new InvalidOperationException("Impossible d'effectuer l'action MovePiece (" + x1 + "," + x2 +"). \n");
        }

        public void UndoLastCommand()
        {
            Command LastCmdToUndo = CommandHistory.Pop().GetCommand();
            if (LastCmdToUndo.CanDo())
            {
                LastCmdToUndo.Undo();
                UndoHistory.Push(new CommandMemento(LastCmdToUndo));
                if (LastCmdToUndo is MovePiece) MovePieceCount--;
                if (LastCmdToUndo is MoveBall) MoveBallCount--;
            }
            else throw new InvalidOperationException("Impossible de défaire la dernière action :" + LastCmdToUndo.GetType() + "\n");
        }

        public void RedoLastCommand()
        {
            if (UndoHistory.Count == 0) throw new InvalidOperationException("Il n'y a aucune action à redo.");
            Command LastCmdToRedo = UndoHistory.Pop().GetCommand();
            if (LastCmdToRedo.CanDo())
            {
                LastCmdToRedo.Do();
                CommandHistory.Push(new CommandMemento(LastCmdToRedo));
                if (LastCmdToRedo is MovePiece) MovePieceCount++;
                if (LastCmdToRedo is MoveBall) MoveBallCount++;
            }
            else throw new InvalidOperationException("Impossible de refaire la dernière action :" + LastCmdToRedo.GetType() + "\n");
        }

        public void MoveBall(int x1, int y1, int x2, int y2)
        {
            if (MoveBallCount == 1 && x1 != -1 && x2 != -1) throw new InvalidOperationException("Seulement 1 action MoveBall autorisée par tour ");
            MoveBall mb = new MoveBall(x1, y1, x2, y2, this.Board);
            if (mb.CanDo())
            {
                mb.Do();
                MoveBallCount++;
                CommandHistory.Push(new CommandMemento(mb));
                UndoHistory.Clear();

                Board.PrintBoard();

                if (MovePieceCount + MoveBallCount == 3 && x1 != -1 && x2 != -1)
                {
                    Command endTurn = new EndTurn(this);
                    endTurn.Do();
                }
            }
            else throw new InvalidOperationException("Impossible d'effectuer l'action MoveBall (" + x1 + "," + x2 + "). \n");
        }
    }
}