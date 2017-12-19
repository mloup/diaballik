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

            Player p = new HumanPlayer("name", "red",1, 2);
            p.moveBall(p1, p2);

            Assert.IsTrue(p2.carryBall);
        }

        [TestMethod]
        public void TestMovePiece()
        {
            Player p = new HumanPlayer("name", "red", 1, 2);
            p.movePiece(p.Pieces[0], 1, 2);

            Assert.IsTrue(p.Pieces[0].coordX==1);
            Assert.IsTrue(p.Pieces[0].coordY == 2);
        }
    }
}
