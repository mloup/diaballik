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
        }

        [TestMethod()]
        public void DoTest()
        {
            int previousPlayer = game.CurrentPlayer;

            EndTurn endTurn = new EndTurn(game.CurrentPlayer);
            endTurn.Do(game);
            int nextPlayer = game.CurrentPlayer;

            Assert.AreNotEqual(previousPlayer, nextPlayer);
        }
    /*
        [TestMethod()]
        public void CanDoTest()
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

        [TestMethod()]
        public void RedoTest()
        {

        }

        [TestMethod()]
        public void UndoTest()
        {

        }*/
    }
}