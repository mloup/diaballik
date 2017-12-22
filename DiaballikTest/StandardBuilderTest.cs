using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System.Linq;

namespace DiaballikTest
{
    [TestClass]
    public class StandardBuilderTest
    {
        StandardBuilder build = new StandardBuilder("Jean", "Jacques", "red", "green", 3);


        [TestMethod]
        public void TestMethodCreatePlayer()
        {
            Player p1 = new HumanPlayer("nom", "red");
            Player p2 = build.CreatePlayer("nom", "red");

            Assert.IsTrue((p1.Name == p2.Name) && (p1.Color == p2.Color));
        }

        [TestMethod]
        public void TestMethodCreatePlayerIA()
        {
            StandardBuilder buildIA = new StandardBuilder("Jean", "Jacques", "red", "green", 7, new NoobStrategy());
            IAStrategy Strat = new NoobStrategy();
            Player p1 = new IAPlayer("nom", "red", Strat);
            IAPlayer p2 = buildIA.CreateIAPlayer();

            Assert.IsTrue((p1.Name == p2.Name) && (p1.Color == p2.Color) && p2.IAStrategy.GetType() == Strat.GetType());
        }

        [TestMethod]
        public void TestMethodPlaceBalls()
        {
            build.CreateBoard();

            int[] coord = { 0, 0 };
            build.PlaceBalls(coord);

            Assert.IsTrue(Game.INSTANCE.Board.Tiles[coord[0], 0]== Tiles.BallPlayer0);
        }

        [TestMethod]
        public void TestMethodComputePieceCoordinates()
        {
            int[] coord = { 0, 0, 1, 0, 2, 0, 0, 2, 1, 2, 2, 2 };
            int[] coord2 = build.ComputePiecesCoordinates();
            Console.Write(coord2[11]);
            Assert.IsTrue(coord[0] == coord2[0] && coord[1] == coord2[1]
                       && coord[2] == coord2[2] && coord[3] == coord2[3]
                       && coord[4] == coord2[4] && coord[5] == coord2[5]
                       && coord[6] == coord2[6] && coord[7] == coord2[7]
                       && coord[8] == coord2[8] && coord[9] == coord2[9]
                       && coord[10] == coord2[10] && coord[11] == coord2[11]);
        }

        [TestMethod]
        public void TestMethodComputeBallsCoordinates()
        {
            int[] coord = { 1, 1 };
            int[] coord2 = build.ComputeBallCoordinates();

            Assert.IsTrue(coord[0] == coord2[0] && coord[1] == coord2[1]);
        }

        [TestMethod]
        public void TestMethodPlacePieces()
        {
            build.CreateBoard();
            int[] coord = build.ComputePiecesCoordinates();

            Assert.IsTrue(Game.INSTANCE.Board.Tiles[0,0] == Tiles.BallPlayer0
                       && Game.INSTANCE.Board.Tiles[1, 0] == Tiles.BallPlayer0
                       && Game.INSTANCE.Board.Tiles[2, 0] == Tiles.BallPlayer0
                       && Game.INSTANCE.Board.Tiles[0, 2] == Tiles.BallPlayer1
                       && Game.INSTANCE.Board.Tiles[1, 2] == Tiles.BallPlayer1
                       && Game.INSTANCE.Board.Tiles[2, 2] == Tiles.BallPlayer1);
        }
    }
}
