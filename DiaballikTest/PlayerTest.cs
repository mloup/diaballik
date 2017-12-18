using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;

namespace DiaballikTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestMoveBall()
        {
            Piece p1 = new Piece(1);
            Piece p2 = new Piece(1);
            p1.carryBall = true;
            Piece[] array = { p1, p2 };

            Player p = new HumanPlayer("name", "red");
            p.moveBall(p1, p2);

            Assert.IsTrue(p2.carryBall);
        }

        [TestMethod]
        public void TestMovePiece()
        {
            Piece p1 = new Piece(1);
            Player p = new HumanPlayer("name", "red");
            p.movePiece(p1, 1, 2);

            Assert.IsTrue(p1.coordX==1);
            Assert.IsTrue(p1.coordY == 2);
        }
    }
}
