using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class EnemyAmongUsBuilder : BuilderGame
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


        private int nbEnemy0;
        private int nbEnemy1;

        public EnemyAmongUsBuilder()
        {
            nbEnemy0 = 0;
            nbEnemy1 = 0;
        }

        ~EnemyAmongUsBuilder()
        {
            throw new System.NotImplementedException();
        }

        public static BuilderGame Create()
        {
            BuilderGame builderGame = new StandardBuilder();
            return builderGame;
        }

        protected override Board FillBoard()
        {
            for (int i = 0; i < board.BoardSize; i++)
            {
                board.Tiles[i, 0] = (i == ((board.BoardSize + 1) / 2)) ? Tiles.BallPlayer0 : GetRandomTiles(0);

            }

            for (int i = 0; i < board.BoardSize; i++)
            {
                board.Tiles[i, board.BoardSize-1] = (i == ((board.BoardSize + 1) / 2)) ? Tiles.BallPlayer1 : GetRandomTiles(1);
            }

            return board;
        }

        private Tiles GetRandomTiles(int playerID)
        {
            int i = new Random().Next(0, 2);
            Tiles tiles = (i == 0) ? Tiles.PiecePlayer0 : Tiles.PiecePlayer1;
            if (i != playerID)
            {
                if (i == 0) nbEnemy1 += 1;
                if (i == 1) nbEnemy0 += 1;
            }
            return tiles;
        }
    }
}