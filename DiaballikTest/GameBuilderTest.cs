using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System.Linq;

namespace DiaballikTest
{
    [TestClass]
    public class GameBuilderTest
    {
        public GameBuilder gb;
        public Player pl0;
        public Player pl1;
        public Player plIA;
        public int nbtiles;
        public Game game;


        [TestInitialize]
        public void Initialize()

        {
            pl0 = new HumanPlayer("Pierre", "rouge");
            pl1 = new HumanPlayer("Marie", "Bleu");
            NoobStrategy algo = new NoobStrategy();
            plIA = new IAPlayer("Robot", "green", algo);
            nbtiles = 3;
        }

        [TestMethod]
        public void TestBallRandomBuilderWithIA()
        {
            gb = new BallRandomBuilder();
            game = gb.SetBoard(nbtiles).SetPlayer0(pl0).SetPlayer1(plIA).Build();

            Assert.AreEqual(nbtiles, gb.MyGameToBuild.Board.BoardSize);
            Assert.IsTrue(gb.MyGameToBuild.GameHasIA);
            Assert.IsFalse(gb.MyGameToBuild.Finished);
            Assert.IsTrue(gb.MyGameToBuild.CurrentPlayer == 0 || gb.MyGameToBuild.CurrentPlayer == 1);
            Assert.AreEqual(pl0, gb.MyGameToBuild.Players[0]);
            Assert.AreEqual(plIA, gb.MyGameToBuild.Players[1]);
        }



        [TestMethod]
        public void TestStandardBuilder()
        {
            gb = new StandardBuilder();
            game = gb.SetBoard(nbtiles).SetPlayer0(pl0).SetPlayer1(pl1).Build();

            Tiles[,] tiles = {  { Tiles.PiecePlayer0, Tiles.BallPlayer0, Tiles.PiecePlayer0 },
                                { Tiles.Default, Tiles.Default, Tiles.Default },
                                { Tiles.PiecePlayer1, Tiles.BallPlayer1, Tiles.PiecePlayer1 } };

            Assert.AreEqual(nbtiles, gb.MyGameToBuild.Board.BoardSize);
            Assert.IsFalse(gb.MyGameToBuild.GameHasIA);
            Assert.IsFalse(gb.MyGameToBuild.Finished);
            Assert.IsTrue(gb.MyGameToBuild.CurrentPlayer == 0 || gb.MyGameToBuild.CurrentPlayer == 1);
            Assert.AreEqual(pl0, gb.MyGameToBuild.Players[0]);
            Assert.AreEqual(pl1, gb.MyGameToBuild.Players[1]);


            for (int i = 0; i < (int)Math.Sqrt(gb.MyGameToBuild.Board.Tiles.Length); i++)
            {
                for (int j = 0; j < (int)Math.Sqrt(gb.MyGameToBuild.Board.Tiles.Length); j++)
                {
                    Assert.AreEqual(tiles[i, j], gb.MyGameToBuild.Board.Tiles[i, j]);
                }
            }
        }
    }
}
