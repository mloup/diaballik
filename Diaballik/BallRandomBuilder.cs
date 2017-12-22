using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class BallRandomBuilder : BuilderGame
    {
        public BallRandomBuilder()
        {
        }

        ~BallRandomBuilder()
        {
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
                board.Tiles[i, 0] = (i == ((board.BoardSize + 1) / 2)) ? Tiles.BallPlayer0 : Tiles.Default;

            }

            for (int i = 0; i < board.BoardSize; i++)
            {
                board.Tiles[i, board.BoardSize - 1] = (i == ((board.BoardSize + 1) / 2)) ? Tiles.BallPlayer1 : Tiles.Default ;
            }

            return board;
        }
    }
}