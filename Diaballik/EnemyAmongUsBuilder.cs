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

        public override BuilderGame Create()
        {
            BuilderGame builderGame = new StandardBuilder();
            return builderGame;
        }

        protected override Board FillBoard()
        {
            for (int i = 0; i < board.BoardSize; i++)
            {
                board.Tiles[i, 0] = (i == ((board.BoardSize + 1) / 2)) ? Tiles.BallPlayer0 : getRandomTiles(0);

            }

            for (int i = 0; i < board.BoardSize; i++)
            {
                board.Tiles[i, board.BoardSize-1] = (i == ((board.BoardSize + 1) / 2)) ? Tiles.BallPlayer1 : getRandomTiles(1);
            }

            return board;
        }

        protected Tiles getRandomTiles(int playerID)
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

        /*
        public override int[] ComputePiecesCoordinates()
        {
            int[] coord = new int[NbTiles * 4];

            Random random = new Random();
            int nEAU = random.Next(1, 4);
            int cpt = 0;
            int[] pos = new int[nEAU];

            int rand = random.Next(0, 2);

            for (int i = 0; i < NbTiles * 2; i += 2)
            {
                rand = random.Next(0, 2);
                if (rand == 1 && cpt < nEAU && (i/2 != NbTiles/2 +1))
                {
                    coord[i + 1] = NbTiles - 1;
                    pos[cpt] = i / 2;
                    cpt++;
                }
                else
                {
                    coord[i + 1] = 0;
                }

                coord[i] = i / 2;
            }
            cpt = 0;
            for (int i = NbTiles * 2; i < NbTiles * 4; i += 2)
            {
                if (cpt < nEAU && ((i - NbTiles * 2) / 2) == pos[cpt])
                {
                    coord[i + 1] = 0;
                    cpt++;
                }
                else
                {
                    coord[i + 1] = NbTiles - 1;
                }
                coord[i] = (i - NbTiles * 2) / 2;
            }

            return coord;
        }
        public override int[] ComputeBallCoordinates()
        {
            int[] res = { NbTiles / 2 + 1, NbTiles / 2 + 1 };
            return res;
        }
        */
    }
}