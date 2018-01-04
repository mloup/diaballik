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
    public class EndTurnTest
    {

        Game game;
        EndTurn endTurn;
        int previousPlayer;

       [TestInitialize]
        public void TestInitialize()
        {
            //game parameters
            int mapSize = 7;
            String nameJ0 = "Pierre";
            String nameJ1 = "Marie";
            String colorJ0 = "bleu";
            String colorJ1 = "rouge";

            Player j0 = new HumanPlayer(nameJ0, colorJ0);
            Player j1 = new HumanPlayer(nameJ1, colorJ1);

            //build
            StandardBuilder gb = StandardBuilder.Create();
            game = gb.SetBoard(mapSize).SetPlayer0(j0).SetPlayer1(j1).Build();

            previousPlayer = game.CurrentPlayer;
            endTurn = new EndTurn(game);
        }

        [TestMethod()]
        public void DoTest()
        {
            int nextPlayer = game.CurrentPlayer;
            endTurn.Do();
            if (previousPlayer == 1)
            {
                Assert.IsTrue(nextPlayer == 0);
            } else
            {
                Assert.IsTrue(nextPlayer == 1);
            }
        }

        [TestMethod()]
        public void CanDoTest1()
        {
            game.MovePieceCount = 1;
            Assert.IsTrue(endTurn.CanDo());
        }

        [TestMethod()]
        public void CanDoTest2()
        {
            Assert.IsFalse(endTurn.CanDo());
        }

        [TestMethod()]
        public void RedoTest()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UndoTest()
        {
            endTurn.Do();
            Command endTurnToUndo = game.CommandHistory.Pop().GetCommand();
            endTurnToUndo.Undo();
        }
    }
}