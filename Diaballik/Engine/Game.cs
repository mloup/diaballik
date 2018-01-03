using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
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

        public void EndTurn(int nextPlayer)
        {
            CurrentPlayer = nextPlayer;
            MoveBallCount = 0;
            MovePieceCount = 0;
        }

        public void MovePiece(int x1, int y1, int x2, int y2)
        {
            if (x1 == -1 && y1 == -1) // Cas où on initialise le Board
            {
                if (x2 == 0) // Init pour joueur0
                {
                    Board.Tiles[x2, y2] = Tiles.PiecePlayer0;
                } else if (x2 == Board.BoardSize - 1) // Init pour joueur1
                {
                    Board.Tiles[x2, y2] = Tiles.PiecePlayer1;
                }
            }
            else // Cas Normal
            {
                if (Board.Tiles[x1, y1] == Tiles.PiecePlayer0 || Board.Tiles[x1, y1] == Tiles.PiecePlayer1)
                {
                    Board.Tiles[x2, y2] = Board.Tiles[x1, y1];
                    Board.Tiles[x1, y1] = Tiles.Default;
                    MovePieceCount++;
                    if (MovePieceCount + MoveBallCount == 3)
                    {
                        int nextPlayer = (CurrentPlayer == 0) ? 1 : 0;
                        Command endTurn = new EndTurn(nextPlayer);
                        endTurn.Do(this);
                    }
                }
                else throw new ArgumentException("Game.MovePiece() : il n'y a pas de Piece à la position (" + x1 + "," + x2 + ").");
            }
        }

        public void MoveBall(int x1, int y1, int x2, int y2)
        {
            if (x1 == -1 && y1 == -1) // Cas où on initialise le Board
            {
                if (x2 == 0) // Init pour joueur0
                {
                    Board.Tiles[x2, y2] = Tiles.BallPlayer0;
                }
                else if (x2 == Board.BoardSize - 1) // Init pour joueur1
                {
                    Board.Tiles[x2, y2] = Tiles.BallPlayer1;
                }
            }
            else // Cas Normal
            {
                Tiles temp = Board.Tiles[x2, y2];
                Board.Tiles[x2, y2] = Board.Tiles[x1, y1];
                Board.Tiles[x1, y1] = temp;
                MoveBallCount++;
                if (MovePieceCount + MoveBallCount == 3)
                {
                    int nextPlayer = (CurrentPlayer == 0) ? 1 : 0;
                    Command endTurn = new EndTurn(nextPlayer);
                    endTurn.Do(this);
                }
            }
        }   
    }
}