using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;

namespace DiaballikTest
{
    [TestClass]
    public class PieceTest
    {
        [TestMethod]
        public void TestMethodEquals()
        {
            Piece p1 = new Piece(1);
            Piece p2 = new Piece(1);

            Assert.IsTrue(p1.Equals(p2));
        }
    }
}
