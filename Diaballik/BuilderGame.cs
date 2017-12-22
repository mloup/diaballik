using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class BuilderGame
    {
        protected Diaballik.Player[] players = new Player[2];
        protected int nbtiles;
        protected int currplayer;
        protected int nbActions;
        protected bool hasIA;
        protected bool endTurnClicked;
        protected bool finished;

        protected Board board;
        protected IAStrategy strat;

        public BuilderGame()
        {
        }

        public BuilderGame SetPlayer0(Player p)
        {
            players[0] = p;
            return this;

        }

        public BuilderGame SetPlayer1(Player p)
        {
            players[1] = p;
            return this;
        }

        public BuilderGame SetIA(IAStrategy strat)
        {
            hasIA = true;
            this.strat = strat;
            return this;
        }

        public BuilderGame SetBoard(int size)
        {
            if (size%2 == 1)
            {
                // lever une exception pour taille de board incorrect
                Console.Write("BuilderGame.SetBoard() : Taille du Plateau incorrect ! (Doit être impair)");
                return null;
            }
            board = new Board(size);
            FillBoard();
            return this;
        }

        protected void ApplyTo(Game game)
        {
            game.Board = board;
            game.GameHasIA = hasIA;
            game.Players = players;
            nbActions = 0;
            endTurnClicked = false;
            finished = false;
            currplayer = new Random().Next(0, 2);
        }

        public Game Build()
        {
            Game game = new Game();
            ApplyTo(game);
            return game;
        }

        protected abstract Board FillBoard();
        

        public bool HasIA
        {
            get => hasIA;
            set
            {
                hasIA = value;
            }
        }

        public IAStrategy Strat
        {
            get => strat;
            set
            {
                strat = value;
            }
        }

        public int NbTiles
        {
            get => nbtiles;
            set
            {
                nbtiles = value;
            }
        }
    }
}