﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class Game
    {
        public static Game INSTANCE = new Game();
        private int currplayer;
        private int nbactions;
        private bool endturnclicked;
        private bool finished;
        private bool gamehasia;
        private Diaballik.Player[] players = new Player[2];
        private Board board;

        public Game()
        {
            Random random = new Random();
            CurrentPlayer = random.Next(0, 2);
            nbActions = 0;
            EndTurnClicked = false;
            finished = false;
            gamehasia = false;
            players[0] = new HumanPlayer("Marie", "bleu");
            players[1] = new HumanPlayer("Pierre", "vert");
            board = new Board();
        }

        public Game(Diaballik.Player[] Players, bool HasIA)
        {
            throw new System.NotImplementedException();
        }

        public Game(Diaballik.Player[] players, bool hasIA, int currentPlayer, bool isFinished, int nbActions)
        {
            throw new System.NotImplementedException();
        }

        ~Game()
        {
            throw new System.NotImplementedException();
        }


        public void setINSTANCE(Game inst)
        {
            INSTANCE = inst;
        }

        public Diaballik.Player[] Players
        {
            get => players;
            set
            {
                players = value;
            }
        }

        public int CurrentPlayer
        {
            get => currplayer;
            set
            {
                currplayer = value;

            }
        }

        public Boolean Finished
        {
            get => finished;
            set
            {
                finished = value;
            }
        }

        public int nbActions
        {
            get => nbactions;
            set
            {
                nbactions = value;
            }
        }

        public bool GameHasIA
        {
            get => gamehasia;
            set
            {
                gamehasia = value;
            }
        }

        public bool EndTurnClicked
        {
            get => endturnclicked;
            set
            {
                endturnclicked = value;
            }
        }

        public Board Board
        {
            get => board;
            set
            {
                board = value;
            }
        }

        public void run()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Après chaque action, test si le compteur est égale à trois, s'il est égal à trois, c'est la fin du tour
        /// </summary>
        public Boolean isEndTurn()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Test le plateau pour regarder si un des joueurs a gagné
        /// </summary>
        public bool isWin()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Passe au tour suivant lors du visionnage d'une partie
        /// </summary>
        public void nextMove()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Passe au tour précédent lors du visionnage d'une partie
        /// </summary>
        public void prevMove()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Sauvegarde l'état en cours de la partie
        /// </summary>
        public void save()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Création d'un nouveau tour
        /// </summary>
        public void newTurn()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Déplacement d'une pièce du plateau
        /// </summary>
        public void movePiece(int x1, int x2, int y1, int y2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Déplacement de la balle entre des pièces
        /// </summary>
        public void moveBall(int x1, int x2, int y1, int y2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Déplacement d'une pièce du plateau
        /// </summary>
        public void movePiece1(int x1, int x2, int y1, int y2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Triggered quand l'utilisateur veut passer son tour. Cette fonction passe la propriété endTurnClicked à true
        /// </summary>
        public void UserEndTurn()
        {
            throw new System.NotImplementedException();
        }        
    }
}