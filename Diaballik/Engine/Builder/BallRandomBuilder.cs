using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class BallRandomBuilder : GameBuilder
    {
        public BallRandomBuilder()
        {
        }

        ~BallRandomBuilder()
        {
        }

        public static GameBuilder Create()
        {
            GameBuilder builderGame = new BallRandomBuilder();
            return builderGame;
        }

        protected override void FillBoard()
        {
            int size = MyGameToBuild.Board.BoardSize;
            Tiles[,] tiles = MyGameToBuild.Board.Tiles;
            for (int i = 0; i < size; i++)
            {
                MovePiece initMovePieceCmd = new MovePiece(-1, -1, 0, i);
                initMovePieceCmd.Do(MyGameToBuild);

            }

            for (int i = 0; i < size; i++)
            {
                MovePiece initMovePieceCmd = new MovePiece(-1, -1, MyGameToBuild.Board.BoardSize - 1, i);
                initMovePieceCmd.Do(MyGameToBuild);
            }

            int rand0 = new Random().Next(0, size);
            int rand1 = new Random().Next(0, size);

            // Placement aléatoire des balles
            MoveBall initMoveBallCmd = new MoveBall(-1, -1, 0, rand0);
            initMoveBallCmd.Do(MyGameToBuild);
            initMoveBallCmd = new MoveBall(-1, -1, size - 1, rand1);
            initMoveBallCmd.Do(MyGameToBuild);
        }
    }
}