using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik.Engine;
using Diaballik.Engine.Builder;

namespace Diaballik.Tests
{
    [TestClass()]
    public class EndTurnTest
    {

        Game game;
        EndTurn endTurn;
        int previousPlayer;

       [TestInitialize]
        public void TestEndTurnInitialize()
        {
            //build
            BoardStrategy strat = BoardStrategy.Standard;
            game = new GameBuilder().SetBoard(7, strat).SetPlayer0("Clément", "vert").SetPlayer1("Pierre", "orange").Build();

            previousPlayer = game.CurrentPlayer;
            endTurn = new EndTurn();
        }

        [TestMethod()]
        public void DoEndTurnTest()
        {
            game.MovePieceCount = 1; // simulation d'un MovePiece afin d'executer la commande endTurn
            endTurn.Do(game);
            int nextPlayer = game.CurrentPlayer;
            if (previousPlayer == 1)
            {
                Assert.IsTrue(nextPlayer == 0);
            } else
            {
                Assert.IsTrue(nextPlayer == 1);
            }
        }

        [TestMethod()]
        public void CanDoEndTurnTest1()
        {
            game.MovePieceCount = 1;
            Assert.IsTrue(endTurn.CanDo(game));
        }

        [TestMethod()]
        public void CanDoEndTurnTest2()
        {
            Assert.IsFalse(endTurn.CanDo(game));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UndoEndTurnTest()
        {
            endTurn.Do(game);
            Command endTurnToUndo = game.CommandHistory.Pop().GetCommand();
            endTurnToUndo.Undo(game);
        }
    }
}