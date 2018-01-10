using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik.Engine.Builder;
using Diaballik.Engine;
using Diaballik.Actions;

namespace Diaballik.Tests
{
    [TestClass()]
    public class MovePieceTest
    {
        MovePiece commandMove;
        Game g;

        [TestInitialize]
        public void InitMovePieceTests()
        {
            BoardStrategy strat = BoardStrategy.Standard;
            g = new GameBuilder().SetBoard(3, strat).SetPlayer0("Clément", "vert").SetPlayer1("Pierre", "orange").Build();
            commandMove = new MovePiece(0, 0, 1, 0);
        }

        [TestMethod()]
        public void DoMovePieceTest1()
        {
            commandMove.Do(g);
            TileTypes[,] expectedTiles = {  { TileTypes.Default, TileTypes.BallPlayer0, TileTypes.PiecePlayer0 },
                                        { TileTypes.PiecePlayer0, TileTypes.Default, TileTypes.Default },
                                        { TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1 } };
            for (int i = 0; i < g.Board.BoardSize; i++)
            {
                for (int j = 0; j < g.Board.BoardSize; j++)
                {
                    Assert.IsTrue(g.Board.Tiles[i, j] == expectedTiles[i, j]);
                }
            }
        }

        [TestMethod()]
        public void DoMovePieceTest2()
        {
            commandMove = new MovePiece(-1, -1, 0, 0);
            commandMove.Do(g);
            Assert.IsTrue(g.Board.Tiles[0, 0] == TileTypes.PiecePlayer0);
        }

        [TestMethod()]
        public void DoMovePieceTest3()
        {
            commandMove = new MovePiece(-1, -1, g.Board.BoardSize-1, 0);
            commandMove.Do(g);
            Assert.IsTrue(g.Board.Tiles[g.Board.BoardSize - 1, 0] == TileTypes.PiecePlayer1);
        }

        [TestMethod()]
        public void CanDoMovePieceTest1()
        {
            Assert.IsTrue(commandMove.CanDo(g) == true);
        }


        [TestMethod()]
        public void CanDoMovePieceTest3()
        {
            commandMove = new MovePiece(0, 0, 0, 2);
            Assert.IsTrue(commandMove.CanDo(g) == false);
            commandMove = new MovePiece(0, 2, 0, 1);
            Assert.IsTrue(commandMove.CanDo(g) == false);
        }

        [TestMethod()]
        public void UndoMovePieceTest()
        {
            commandMove.Do(g);
            commandMove.Undo(g);
            TileTypes[,] tiles = {  { TileTypes.PiecePlayer0, TileTypes.BallPlayer0, TileTypes.PiecePlayer0 },
                                { TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                { TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1 } };

            for (int i = 0; i < g.Board.BoardSize; i++)
            {
                for (int j = 0; j < g.Board.BoardSize; j++)
                {
                    Assert.IsTrue(g.Board.Tiles[i, j] == tiles[i,j]);
                }
            }

        }
    }
}