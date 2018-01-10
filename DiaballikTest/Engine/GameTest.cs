using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik.Engine.Builder;
using Diaballik.Actions;

namespace Diaballik.Engine.Tests
{
    [TestClass()]
    public class GameTest
    {
        Game g;

        [TestInitialize]
        public void InitMovePieceTests()
        {
            BoardStrategy strat = BoardStrategy.Standard;
            g = new GameBuilder().SetBoard(3, strat).SetPlayer0("Clément", "vert").SetPlayer1("Pierre", "orange").Build();
        }

        [TestMethod()]
        public void IsWinTest()
        {
            g.Update(new MovePiece(2, 0, 1, 0));
            g.Update(new MovePiece(1, 0, 1, 1));
            g.Update(new EndTurn());
            g.Update(new MovePiece(0, 0, 1, 0));
            g.Update(new MoveBall(0, 1, 1, 0));
            g.Update(new MovePiece(0, 1, 0, 0));
            g.Update(new MoveBall(1, 0, 0, 0));
            g.Update(new MovePiece(1, 0, 2, 0));
            g.Update(new EndTurn());
            g.Update(new MoveBall(0, 0, 2, 0));
            Assert.IsTrue(g.IsWin());
        }

        [TestMethod()]
        public void NextMoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PrevMoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EndTurnTest()
        {
            g.Update(new MovePiece(0, 0, 1, 0));
            g.Update(new EndTurn());
            Command cmd = g.CommandHistory.Pop().GetCommand();
            Assert.IsTrue(cmd is EndTurn);
        }

        [TestMethod()]
        public void MovePieceTest1()
        {
            g.Update(new MovePiece(0, 0, 1, 0));
            MovePiece cmd = (MovePiece) g.CommandHistory.Pop().GetCommand();
            Assert.IsTrue(cmd.NextX == 1);
            Assert.IsTrue(cmd.NextY == 0);
            Assert.IsTrue(cmd.PrevX == 0);
            Assert.IsTrue(cmd.PrevY == 0);
            Assert.IsTrue(g.UndoHistory.Count == 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MovePieceTest2()
        {
            g.Update(new MovePiece(0, 0, 1, 0));
            g.Update(new MovePiece(1, 0, 2, 0));
            g.Update(new MovePiece(0, 2, 1, 2));
        }

        [TestMethod()]
        public void MovePieceTest3()
        {
            g.Update(new MovePiece(0, 0, 1, 0));
            g.Update(new MoveBall(0, 1, 1, 0));
            g.Update(new MovePiece(0, 2, 1, 2));
            Command cmd = g.CommandHistory.Pop().GetCommand();
            Assert.IsTrue(cmd is EndTurn);

        }

        [TestMethod()]
        public void UndoLastCommandTest()
        {
            g.Update(new MovePiece(0, 0, 1, 0));
            g.UndoLastCommand();
            TileTypes[,] tiles = {  { TileTypes.PiecePlayer0, TileTypes.BallPlayer0, TileTypes.PiecePlayer0 },
                                { TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                { TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1 } };
            for (int i = 0; i < g.Board.BoardSize; i++)
            {
                for (int j = 0; j < g.Board.BoardSize; j++)
                {
                    Assert.IsTrue(g.Board.Tiles[i, j] == tiles[i, j]);
                }
            }
            Assert.IsTrue(g.MovePieceCount == 0);
        }

        [TestMethod()]
        public void RedoLastCommandTest()
        {
            g.Update(new MovePiece(0, 0, 1, 0));
            g.UndoLastCommand();
            g.RedoLastCommand();
            TileTypes[,] tiles = {  { TileTypes.Default, TileTypes.BallPlayer0, TileTypes.PiecePlayer0 },
                                { TileTypes.PiecePlayer0, TileTypes.Default, TileTypes.Default },
                                { TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1 } };
            for (int i = 0; i < g.Board.BoardSize; i++)
            {
                for (int j = 0; j < g.Board.BoardSize; j++)
                {
                    Assert.IsTrue(g.Board.Tiles[i, j] == tiles[i, j]);
                }
            }
            Assert.IsTrue(g.MovePieceCount == 1);
        }

        [TestMethod()]
        public void MoveBallTest()
        {
            g.Update(new MoveBall(0, 1, 0, 0));
            MoveBall cmd = (MoveBall) g.CommandHistory.Pop().GetCommand();
            Assert.IsTrue(cmd.NextX == 0);
            Assert.IsTrue(cmd.NextY == 0);
            Assert.IsTrue(cmd.PrevX == 0);
            Assert.IsTrue(cmd.PrevY == 1);
            Assert.IsTrue(g.UndoHistory.Count == 0);
        }
    }
}