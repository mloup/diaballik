namespace Diaballik.Engine.Builder
{
    public class StandardBuilder : GameBuilder
    {
        public StandardBuilder()
        {

        }

        ~StandardBuilder()
        {

        }

        public static StandardBuilder Create()
        {
            StandardBuilder builderGame = new StandardBuilder();
            return builderGame;
        }

        protected override void FillBoard()
        {
            for (int i = 0; i < MyGameToBuild.Board.BoardSize; i++)
            {
                //this.Board.Tiles[0,i] = (i + 1 == ((Board.BoardSize + 1) / 2)) ? Tiles.BallPlayer0 : Tiles.PiecePlayer0;
                MyGameToBuild.MovePiece(-1, -1, 0, i);
              
            }
            for (int i = 0; i < MyGameToBuild.Board.BoardSize; i++)
            {
                //this.Board.Tiles[Board.BoardSize-1,i] = (i + 1 == ((Board.BoardSize + 1) / 2)) ? Tiles.BallPlayer1 : Tiles.PiecePlayer1;
                MyGameToBuild.MovePiece(-1, -1, MyGameToBuild.Board.BoardSize - 1, i);
            }

            MyGameToBuild.MoveBall(-1, -1, 0, ((MyGameToBuild.Board.BoardSize + 1) / 2) - 1);
            MyGameToBuild.MoveBall(-1, -1, MyGameToBuild.Board.BoardSize - 1, ((MyGameToBuild.Board.BoardSize + 1) / 2) - 1);
            MyGameToBuild.EndTurn(); // pour remmettre les compteur à 0
        }
    }
}