using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class EnemyAmongUsBuilder : GameBuilder
    {
        public EnemyAmongUsBuilder()
        {

        }

        ~EnemyAmongUsBuilder()
        {
            
        }

        public static GameBuilder Create()
        {
            GameBuilder builderGame = new EnemyAmongUsBuilder();
            return builderGame;
        }

        protected override void FillBoard()
        {
            int size = MyGameToBuild.Board.BoardSize;
            Tiles[,] tiles = MyGameToBuild.Board.Tiles;

            // initiaisation du Board avec que des Pieces
            for (int i = 0; i < size; i++)
            {
                MovePiece initMovePieceCmd = new MovePiece(-1, -1, 0, i);
                initMovePieceCmd.Do(MyGameToBuild);

            }

            for (int i = 0; i < size; i++)
            {
                MovePiece initMovePieceCmd = new MovePiece(-1, -1, size - 1, i);
                initMovePieceCmd.Do(MyGameToBuild);
            }

            // placement des Balles au centre
            MoveBall initMoveBallCmd0 = new MoveBall(-1, -1, 0, ((size + 1) / 2) - 1);
            initMoveBallCmd0.Do(MyGameToBuild);

            MoveBall initMoveBallCmd1 = new MoveBall(-1, -1, size - 1, ((size + 1) / 2) - 1);
            initMoveBallCmd1.Do(MyGameToBuild);

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
            MovePiece randomMovePieceCmd = new MovePiece(-1, -1, 0, rand0_1);
            randomMovePieceCmd.Do(MyGameToBuild);
            randomMovePieceCmd = new MovePiece(-1, -1, 0, rand0_2);
            randomMovePieceCmd.Do(MyGameToBuild);
            randomMovePieceCmd = new MovePiece(-1, -1, size - 1, rand1_1);
            randomMovePieceCmd.Do(MyGameToBuild);
            randomMovePieceCmd = new MovePiece(-1, -1, size - 1, rand1_2);
            randomMovePieceCmd.Do(MyGameToBuild);
        }
    }
}