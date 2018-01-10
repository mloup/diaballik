using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik.Engine;
using Diaballik.Engine.Builder;
using Diaballik.Actions;

namespace Diaballik.Tests
{
    [TestClass()]
    public class MoveBallTest
    {
        MoveBall commandMove;
        Game g;

        [TestInitialize]
        public void InitMovePieceTests()
        {
            BoardStrategy strat = BoardStrategy.Standard;
            g = new GameBuilder().SetBoard(3, strat).SetPlayer0("Clément", "vert").SetPlayer1("Pierre", "orange").Build();
            commandMove = new MoveBall(0, 1, 0, 0);
        }

        [TestMethod()]
        public void DoMoveBallTest1()
        {
            commandMove.Do(g);
            TileTypes[,] expectedTilesSize3 = {  { TileTypes.BallPlayer0, TileTypes.PiecePlayer0, TileTypes.PiecePlayer0 },
                                        { TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                        { TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1 } };
            for (int i = 0; i < g.Board.BoardSize; i++)
            {
                for (int j = 0; j < g.Board.BoardSize; j++)
                {
                    Assert.IsTrue(g.Board.Tiles[i, j] == expectedTilesSize3[i, j]);
                }
            }
        }

        [TestMethod()]
        public void DoMoveBallTest2()
        {
            commandMove = new MoveBall(-1, -1, 0, 0);
            commandMove.Do(g);
            Assert.IsTrue(g.Board.Tiles[0, 0] == TileTypes.BallPlayer0);
        }

        [TestMethod()]
        public void DoMoveBallTest3()
        {
            BoardStrategy strat = BoardStrategy.Standard;
            g = new GameBuilder().SetBoard(5, strat).SetPlayer0("Clément", "vert").SetPlayer1("Pierre", "orange").Build();
            commandMove = new MoveBall(0, 2, 0, 1);
            //Console.Write(g.Board.ToString());
            //Console.Write(commandMove.ToString());

            commandMove.Do(g);
            //Console.Write(g.Board.ToString());
            TileTypes[,] expectedTilesSize5 = {  { TileTypes.PiecePlayer0, TileTypes.BallPlayer0, TileTypes.PiecePlayer0, TileTypes.PiecePlayer0, TileTypes.PiecePlayer0 },
                                        { TileTypes.Default, TileTypes.Default, TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                        { TileTypes.Default, TileTypes.Default, TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                        { TileTypes.Default, TileTypes.Default, TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                        { TileTypes.PiecePlayer1, TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1, TileTypes.PiecePlayer1} };

            for (int i = 0; i < g.Board.BoardSize; i++)
            {
                for (int j = 0; j < g.Board.BoardSize; j++)
                {
                    Assert.IsTrue(g.Board.Tiles[i, j] == expectedTilesSize5[i, j]);
                }
            }
        }

        [TestMethod()]
        public void CanDoMoveBallTest()
        {
            Assert.IsTrue(commandMove.CanDo(g));
        }

        [TestMethod()]
        public void UndoMoveBallTest()
        {
            commandMove.Do(g);
            commandMove.Undo(g);

            TileTypes[,] expectedTiles = {  {  TileTypes.PiecePlayer0, TileTypes.BallPlayer0, TileTypes.PiecePlayer0 },
                                        { TileTypes.Default, TileTypes.Default, TileTypes.Default },
                                        { TileTypes.PiecePlayer1, TileTypes.BallPlayer1, TileTypes.PiecePlayer1 } };

            for (int i = 0; i < g.Board.BoardSize; i++)
            {
                for (int j = 0; j < g.Board.BoardSize; j++)
                {
                    Assert.IsTrue(g.Board.Tiles[i, j] == expectedTiles[i, j]);
                }
            }
        }
    }
}