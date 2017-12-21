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
            Player p1 = new HumanPlayer("nom", "red", 0, 3);
            Player p2 = build.CreatePlayer("nom", "red", 0);

            Assert.IsTrue((p1.Name == p2.Name) && (p1.Color == p2.Color) && p1.Pieces.Length == p2.Pieces.Length);
        }

        [TestMethod]
        public void TestMethodCreatePlayerIA()
        {
            StandardBuilder buildIA = new StandardBuilder("Jean", "Jacques", "red", "green", 7, new NoobStrategy());
            IAStrategy Strat = new NoobStrategy();
            Player p1 = new HumanPlayer("nom", "red", 0, 7);
            IAPlayer p2 = buildIA.CreateIAPlayer();

            Assert.IsTrue((p1.Name == p2.Name) && (p1.Color == p2.Color) && p1.Pieces.Length == p2.Pieces.Length && p2.IAStrategy.GetType() == Strat.GetType());
        }

        [TestMethod]
        public void TestMethodPlaceBalls()
        {
            Player[] players = { build.CreatePlayer(build.Name1, build.Color1, 0), build.CreatePlayer(build.Name2, build.Color2, 1) };
            Game.INSTANCE.Players = players;

            int[] coord = { 0, 0 };
            build.PlaceBalls(coord);

            Assert.IsTrue(Game.INSTANCE.Players[0].Pieces[0].carryBall && Game.INSTANCE.Players[1].Pieces[0].carryBall);
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

        }
    }
}
