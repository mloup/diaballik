using System;
using System.Threading;
using Diaballik;
using Diaballik.Actions;
using Diaballik.Actors;
using Diaballik.Actors.Strategy;
using Diaballik.Engine;
using Diaballik.Engine.Builder;

namespace TestWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p0 = new HumanPlayer("Marie", "rouge");
            var algo = new NoobStrategy();
            Player p1 = new IAPlayer("Pierre", "noir", algo);

            Game g = new GameBuilder().SetBoard(5, BoardStrategy.Standard).SetPlayer1(p1).SetPlayer0(p0).Build();

            g.CurrentPlayer = 0; // Simulate Human Player Turn
            g.Update(new MovePiece(0, 0, 1, 0));
            g.Update(new MovePiece(1, 0, 2, 0));
            g.Update(new EndTurn());

            // IA turn                
            algo.PlayOneAction(g);
            /*
            Thread.Sleep(3000); // simule la réflexion 
            algo.PlayOneAction(g);
            Thread.Sleep(3000);
            algo.PlayOneAction(g);
            */
            g.Update(new EndTurn());
                
            g.Update(new MoveBall(0, 2, 2, 0));
            g.Update(new MovePiece(0, 2, 1, 2));
            g.Update(new MovePiece(0, 4, 1, 4));

            Console.Write(g.ToString());
            Thread.Sleep(100000);
        }
    }
}
