using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class Game
    {
        private int currplayer;
        private int nbactions;
        private int nbcaseboard;
        private bool endturnclicked;
        private bool finished;
        private bool gamehasia;
        private Diaballik.Player[] players;

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

        public Diaballik.Player[] Players
        {
            get => players;
            set
            {
                players = value;
            }
        }

        public int currentPlayer
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

        public bool gameHasIA
        {
            get => gamehasia;
            set
            {
                gamehasia = value;
            }
        }

        public bool endTurnClicked
        {
            get => endturnclicked;
            set
            {
                endturnclicked = value;
            }
        }

        public int nbCaseBoard
        {
            get => nbcaseboard;
            set
            {
                nbcaseboard = value;
            }
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