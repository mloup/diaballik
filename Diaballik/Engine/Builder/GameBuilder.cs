using Diaballik.Actors;
using Diaballik.Actors.Strategy;
using System;
using System.Collections.Generic;

namespace Diaballik.Engine.Builder
{
    public enum BoardStrategy
    {
        Standard = 0,
        BallRandom = 1,
        EnemyAmongUs = 2
    }

    public class GameBuilder
    {
        public Player P0 { get; private set; }
        public Player P1 { get; private set; }
        public Board Board { get; set; }


        public GameBuilder SetPlayer0(string nom, string color, IAStrategy strat = null)
        {
            P0 =  (strat != null) ? (Player) new IAPlayer(nom, color, strat) : new HumanPlayer(nom, color);
            return this;

        }

        public GameBuilder SetPlayer1(string nom, string color, IAStrategy strat = null)
        {

            P1 = (strat != null) ? (Player)new IAPlayer(nom, color, strat) : new HumanPlayer(nom, color);
            return this;
        }


        public GameBuilder SetBoard(int size, BoardStrategy boardStrat )
        {
            if (size % 2 == 1)
            {
                Board = new Board(size);
                switch (boardStrat)
                {
                    case BoardStrategy.Standard:
                        GameScenario.FillBoardStandard(Board);
                        break;
                    case BoardStrategy.BallRandom:
                        GameScenario.FillBoardBallRandom(Board);
                        break;
                    case BoardStrategy.EnemyAmongUs:
                        GameScenario.FillBoardEnemyAmongUs(Board);
                        break;
                }
                return this;
            }
            else
            {
                // lever une exception pour taille de board incorrect
                throw new ArgumentException("La taille du Board doit être impaire");
            }
        }

        public GameBuilder SetPlayer0(Player pl0)
        {
            P0 = pl0;
            return this;
        }

        public GameBuilder SetPlayer1(Player pl1)
        {
            P1 = pl1;
            return this;
        }

        public GameBuilder SetBoard(Board b)
        {
            if (b.BoardSize % 2 == 1)
            {
                Board = b;
                return this;
            }
            else
            {
                // lever une exception pour taille de board incorrect
                throw new ArgumentException("La taille du Board doit être impaire");
            }
        }

        public virtual Game Build()
        {
            if (P0 == null || P1 == null || Board == null) throw new ArgumentException("Il manque au moins un élément pour construire une partie.");

            var game = new Game(P0, P1, Board);
            return game;
        }
    }



    static class GameScenario
    {
        public static void FillBoardBallRandom(Board b)
        {
            int size = b.BoardSize;
            var tiles = b.Tiles;
            for (int i = 0; i < size; i++)
            {
                b.MovePiece(-1, -1, 0, i);

            }

            for (int i = 0; i < size; i++)
            {
                b.MovePiece(-1, -1, b.BoardSize - 1, i);
            }

            int rand0 = new Random().Next(0, size);
            int rand1 = new Random().Next(0, size);

            // Placement aléatoire des 2 balles
            b.MoveBall(-1, -1, 0, rand0);
            b.MoveBall(-1, -1, size - 1, rand1);
        }


        public static void FillBoardEnemyAmongUs(Board b)
        {
            int size = b.BoardSize;
            var tiles = b.Tiles;

            // initiaisation du Board avec que des Pieces
            for (int i = 0; i < size; i++)
            {
                b.MovePiece(-1, -1, 0, i);

            }

            for (int i = 0; i < size; i++)
            {
                b.MovePiece(-1, -1, size - 1, i);
            }

            // placement des Balles au centre
            b.MoveBall(-1, -1, 0, ((size + 1) / 2) - 1);

            b.MoveBall(-1, -1, size - 1, ((size + 1) / 2) - 1);

            // Générer des nombres aléatoires
            int rand0_1 = new Random().Next(0, size);
            int rand0_2 = new Random().Next(0, size);
            int rand1_1 = new Random().Next(0, size);
            int rand1_2 = new Random().Next(0, size);

            // il faut etre certain que rand0_1 != rand0_2 && rand1_1 != rand1_2 && randx_x != là où est placée la balle
            while (rand0_1 == ((size + 1) / 2) - 1)
                rand0_1 = new Random().Next(0, size);
            while (rand1_1 == ((size + 1) / 2) - 1)
                rand1_1 = new Random().Next(0, size);
            while (rand0_2 == rand0_1 || rand0_2 == ((size + 1) / 2) - 1)
                rand0_2 = new Random().Next(0, size);
            while (rand1_2 == rand1_1 || rand1_2 == ((size + 1) / 2) - 1)
                rand1_2 = new Random().Next(0, size);

            // Placement aléatoire des 2 pièces ennemies de chaque côtés
            b.MovePiece(-1, -1, 0, rand0_1);
            b.MovePiece(-1, -1, 0, rand0_2);
            b.MovePiece(-1, -1, size - 1, rand1_1);
            b.MovePiece(-1, -1, size - 1, rand1_2);
        }


        public static void FillBoardStandard(Board b)
        {
            for (int i = 0; i < b.BoardSize; i++)
            {
                //Tiles[0,i] = (i + 1 == ((b.BoardSize + 1) / 2)) ? Tiles.BallPlayer0 : Tiles.PiecePlayer0;
                b.MovePiece(-1, -1, 0, i);

            }
            for (int i = 0; i < b.BoardSize; i++)
            {
                //this.Board.Tiles[b.BoardSize-1,i] = (i + 1 == ((b.BoardSize + 1) / 2)) ? Tiles.BallPlayer1 : Tiles.PiecePlayer1;
                b.MovePiece(-1, -1, b.BoardSize - 1, i);
            }

            b.MoveBall(-1, -1, 0, ((b.BoardSize + 1) / 2) - 1);
            b.MoveBall(-1, -1, b.BoardSize - 1, ((b.BoardSize + 1) / 2) - 1);
        }
    }
}