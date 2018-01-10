using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diaballik.Engine.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik.Actors;
using Diaballik.Engine;

namespace Diaballik.Engine.Builder.Tests
{
    [TestClass()]
    public class LoadGameBuilderTest
    {
        /*[TestMethod]
        public void TestLoadGameBuild()
        {
            StandardBuilder gb = StandardBuilder.Create();
            Player p0 = new HumanPlayer("Pierre", "rouge");
            Player p1 = new HumanPlayer("Marie", "Bleu");
            Game game = gb.SetBoard(5).SetPlayer0(p0).SetPlayer1(p1).Build();

            game.MovePiece(0, 0, 1, 0);
            game.MovePiece(1, 0, 2, 0);
            game.MoveBall(0, 2, 2, 0);

            string filename = @"C:\Temp\diaballik_loadgamebuildertest.save";
            GameSaveManager.Save(game, filename);

            LoadGameBuilder lgb = new LoadGameBuilder();
            lgb.SetFileName(filename);

            Assert.AreEqual(filename, lgb.FileName);

            Game loaded = lgb.Build();

            Assert.AreEqual(game.GameHasIA, loaded.GameHasIA);
            Assert.AreEqual(game.MoveBallCount, loaded.MoveBallCount);
            Assert.AreEqual(game.MovePieceCount, loaded.MovePieceCount);
            Assert.AreEqual(game.CurrentPlayer, loaded.CurrentPlayer);
            Assert.AreEqual(game.ToString(), loaded.ToString());
        }*/
    }
}