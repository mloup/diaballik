using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diaballik
{
    public class StandardBuilder : GameBuilder
    {
        public StandardBuilder()
        {

        }

        ~StandardBuilder()
        {

        }

        public static GameBuilder Create()
        {
            GameBuilder builderGame = new StandardBuilder();
            return builderGame;
        }

        protected override void FillBoard()
        {
            for (int i = 0; i < MyGameToBuild.Board.BoardSize; i++)
            {
                //this.Board.Tiles[0,i] = (i + 1 == ((Board.BoardSize + 1) / 2)) ? Tiles.BallPlayer0 : Tiles.PiecePlayer0;
                MovePiece initMovePieceCmd = new MovePiece(-1, -1, 0, i);
                initMovePieceCmd.Do(MyGameToBuild);
              
            }
            for (int i = 0; i < MyGameToBuild.Board.BoardSize; i++)
            {
                //this.Board.Tiles[Board.BoardSize-1,i] = (i + 1 == ((Board.BoardSize + 1) / 2)) ? Tiles.BallPlayer1 : Tiles.PiecePlayer1;
                MovePiece initMovePieceCmd = new MovePiece(-1, -1, MyGameToBuild.Board.BoardSize - 1, i);
                initMovePieceCmd.Do(MyGameToBuild);
            }

            MoveBall initMoveBallCmd0 = new MoveBall(-1, -1, 0, ((MyGameToBuild.Board.BoardSize + 1) / 2) - 1);
            initMoveBallCmd0.Do(MyGameToBuild);

            MoveBall initMoveBallCmd1 = new MoveBall(-1, -1, MyGameToBuild.Board.BoardSize - 1, ((MyGameToBuild.Board.BoardSize + 1) / 2) - 1);
            initMoveBallCmd1.Do(MyGameToBuild);
        }
    }
}