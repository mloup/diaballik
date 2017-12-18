using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System.Linq;

namespace DiaballikTest
{
    [TestClass]
    public class PieceFrabriqueTest
    {
        [TestMethod]
        public void TestMethodCreateNPieces()
        {
            Piece p1 = new Piece(1);
            Piece p2 = new Piece(1);
            Piece[] array = { p1, p2 };

            Piece[] array2 = PieceFactory.INSTANCE.CreateNPieces(2, 1);

            //Assert.IsNotNull(array2);
            Assert.IsTrue(array[0].Equals(array2[0]));
            Assert.IsTrue(array[1].Equals(array2[1]));
        }
    }
}
