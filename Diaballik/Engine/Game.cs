using Diaballik.Actions;
using Diaballik.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik.Engine
{
    [Serializable]
    public class Game
    {
        public Stack<CommandMemento> CommandHistory { get; set; }
        public Stack<CommandMemento> UndoHistory { get; set; }
        public Player[] Players { get; set; }
        public int MovePieceCount { get; set; }
        public int MoveBallCount { get; set; }
        public int CurrentPlayer { get; set; }
        public bool Finished { get; set; }
        public Player VictoriousPlayer { get; set; }
        public bool GameHasIA { get; set; }
        public Board Board { get; set; }

        public Game(Player p0, Player p1, Board b)
        {
            Players = new Player[2] { p0, p1 };
            if (p0 is IAPlayer) {
                Players[0] = p1;
                Players[1] = p0;
            }
            
            GameHasIA = (Players[1] is IAPlayer) ? true : false;
            CommandHistory = new Stack<CommandMemento>();
            UndoHistory = new Stack<CommandMemento>();
            MoveBallCount = 0;
            MovePieceCount = 0;
            Finished = false;
            CurrentPlayer = new Random().Next(0, 2);
            VictoriousPlayer = null;
            Board = b;
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
                if (Board.Tiles[0, i] == TileTypes.BallPlayer1)
                {
                    VictoriousPlayer = Players[0];
                    res = true;
                }
            }
            for (int i = 0; i < Board.BoardSize; i++)
            {
                if (Board.Tiles[Board.BoardSize - 1, i] == TileTypes.BallPlayer0)
                {
                    VictoriousPlayer = Players[1];
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

        // Ne Marche pas ! (Le Board de ma commande n'est pas le Board de ma game actuelle)
        public void UndoLastCommand()
        {
            Command LastCmdToUndo = CommandHistory.Pop().GetCommand();

            if (LastCmdToUndo.CanUndo(this))
            {
                LastCmdToUndo.Undo(this);
                UndoHistory.Push(new CommandMemento(LastCmdToUndo));
                if (LastCmdToUndo is MovePiece) MovePieceCount--;
                if (LastCmdToUndo is MoveBall) MoveBallCount--;
            }
            else throw new InvalidOperationException("Impossible de défaire la dernière action :" + LastCmdToUndo.GetType() + " : " + LastCmdToUndo.ToString());
        }

        public void RedoLastCommand()
        {
            if (UndoHistory.Count == 0) throw new InvalidOperationException("Il n'y a aucune action à redo.");
            Command LastCmdToRedo = UndoHistory.Pop().GetCommand();
            if (LastCmdToRedo.CanDo(this))
            {
                LastCmdToRedo.Do(this);
                CommandHistory.Push(new CommandMemento(LastCmdToRedo));
                if (LastCmdToRedo is MovePiece) MovePieceCount++;
                if (LastCmdToRedo is MoveBall) MoveBallCount++;
            }
            else throw new InvalidOperationException("Impossible de refaire la dernière action :" + LastCmdToRedo.GetType() + "\n");
        }

        public void Update(Command cmd)
        {
            if (cmd.CanDo(this))
            {
                cmd.Do(this);
                if (cmd is MoveBall) MoveBallCount++;
                if (cmd is MovePiece) MovePieceCount++;
                CommandHistory.Push(new CommandMemento(cmd));
                UndoHistory.Clear();

                //Console.Write(Board.ToString());
                if (IsWin())
                {
                    VictoriousPlayer = Players[CurrentPlayer];
                }
                if (IsEndTurn())
                {
                    Command endTurn = new EndTurn();
                    CommandHistory.Push(new CommandMemento(endTurn));
                    endTurn.Do(this);
                }
            }
            else throw new InvalidOperationException("Impossible d'effectuer l'action " + cmd.GetType() + " : " + cmd.ToString());
        }

        public override String ToString()
        {
            string res = "Trace Jeu:\n";
            res += "\tEtat de la partie: " + ((IsWin())? "partie terminée": "partie non terminée") + "\n";
            res += Board.ToString();
            res += "\tJoueurs 0: " + Players[0].ToString();
            res += "\tJoueurs 1: " + Players[1].ToString();
            res += "\tJoueur Courant: " + CurrentPlayer + "\n";
            res += "\tMovePieceCount: " + MovePieceCount + "\n";
            res += "\tMoveBallCount: " + MoveBallCount + "\n";
            res += "\tActions stockées : \n";
            if (CommandHistory.Count == 0)
                res += "\t\tPas d'actions.\n";
            else
            {
                foreach (CommandMemento command in CommandHistory)
                {
                    res += command.GetCommand().ToString();
                }
            }
            res += "Fin trace Jeu\n";
            return res;
        }
    }
}