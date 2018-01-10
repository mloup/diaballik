using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System.Linq;
using Diaballik.Engine.Builder;
using Diaballik.Actors;
using Diaballik.Engine;
using Diaballik.Actors.Strategy;

namespace DiaballikTest.Engine.Builder.Tests
{
    [TestClass]
    public class GameBuilderTest
    {
        public GameBuilder gb;
        public Player pl0;
        public Player pl1;
        public Player plIA;
        public Game game;


        [TestInitialize]
        public void Initialize()

        {
            pl0 = new HumanPlayer("Pierre", "rouge");
            pl1 = new HumanPlayer("Marie", "Bleu");
            NoobStrategy algo = new NoobStrategy();
            plIA = new IAPlayer("Robot", "green", algo);
        }

        [TestMethod]
        public void TestBallRandomBuilderWithIA()
        {
            BoardStrategy strat = BoardStrategy.BallRandom;
            game = new GameBuilder().SetBoard(3, strat).SetPlayer0(pl0).SetPlayer1(plIA).Build();

            Assert.AreEqual(3, game.Board.BoardSize);
            Assert.IsTrue(game.GameHasIA);
            Assert.IsFalse(game.Finished);
            Assert.IsTrue(game.CurrentPlayer == 0 || game.CurrentPlayer == 1);
            Assert.AreEqual(pl0, game.Players[0]);
            Assert.AreEqual(plIA, game.Players[1]);
        }



        [TestMethod]
        public void TestStandardBuilder()
        {
            BoardStrategy strat = BoardStrategy.Standard;
            game = new GameBuilder().SetBoard(3, strat).SetPlayer0(pl0).SetPlayer1(plIA).Build();

            TileTypes[,] tiles = {  { TileTypes.PiecePlayer0, TileTypes.BallPlayer0, TileTypes.PiecePlayer0 },
                                { TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                { TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1 } };

            Assert.AreEqual(3, game.Board.BoardSize);
            Assert.IsTrue(game.GameHasIA);
            Assert.IsFalse(game.Finished);
            Assert.IsTrue(game.CurrentPlayer == 0 || game.CurrentPlayer == 1);
            Assert.AreEqual(pl0, game.Players[0]);
            Assert.AreEqual(plIA, game.Players[1]);


            for (int i = 0; i < (int)Math.Sqrt(game.Board.Tiles.Length); i++)
            {
                for (int j = 0; j < (int)Math.Sqrt(game.Board.Tiles.Length); j++)
                {
                    Assert.AreEqual(tiles[i, j], game.Board.Tiles[i, j]);
                }
            }
        }
    }
}
