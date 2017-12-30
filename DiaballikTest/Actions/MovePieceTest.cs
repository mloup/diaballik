using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaballik.Tests
{
    [TestClass()]
    public class MovePieceTest
    {
        [TestInitialize]
        public void InitTests()
        {
            Game g = new StandardBuilder().SetBoard(3).Build();
            MovePiece commandMove = new MovePiece(0, 0, 0, 1);
            commandMove.Do(g);
            Tiles[,] expectedTiles = {  { Tiles.Default, Tiles.BallPlayer0, Tiles.PiecePlayer0 },
                                { Tiles.PiecePlayer0, Tiles.Default, Tiles.Default },
                                { Tiles.PiecePlayer1, Tiles.BallPlayer1, Tiles.PiecePlayer1 } };
        }

        [TestMethod()]
        public void DoTest()
        {

        }

        [TestMethod()]
        public void CanDoTest()
        {

        }

        [TestMethod()]
        public void RedoTest()
        {

        }

        [TestMethod()]
        public void UndoTest()
        {

        }

        [TestMethod()]
        public void DoneTest()
        {

        }

        [TestMethod()]
        public void IsDoneTest()
        {

        }
    }
}