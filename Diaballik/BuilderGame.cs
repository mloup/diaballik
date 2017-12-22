using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public abstract class BuilderGame
    {
        private Diaballik.Player[] players = new Player[2];
        private int nbtiles;
        private int currplayer;
        private int nbActions;
        private bool hasIA;
        private bool endTurnClicked;
        private bool finished;

        private Board board;
        private IAStrategy strat;

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

        public abstract BuilderGame Create();
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


        public void PlacePieces(int[] coord)
        {
            for(int i = 0; i < NbTiles*2; i+=2)
            {
                MovePiece move = new MovePiece(-1, -1, coord[i], coord[i + 1]);
                move.Do();
                Actions.INSTANCE.push(move);
            }
            for (int i = NbTiles * 2; i < NbTiles * 4; i += 2)
            {
                MovePiece move = new MovePiece(-1, -1, coord[i], coord[i + 1]);
                move.Do();
                Actions.INSTANCE.push(move);
            }
        }

        public void PlaceBalls(int[] coord)
        {
            Game.INSTANCE.Board.Tiles[coord[0],0 ] = Tiles.BallPlayer0;
            Game.INSTANCE.Board.Tiles[coord[1], Game.INSTANCE.Board.BoardSize - 1] = Tiles.BallPlayer1;
        }

        public abstract int[] ComputePiecesCoordinates();
        public abstract int[] ComputeBallCoordinates();
    }
}