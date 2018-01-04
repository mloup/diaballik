using System;
using System.Threading;
using Diaballik;

namespace TestWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player p0 = new HumanPlayer("Marie", "rouge");
                var algo = new NoobStrategy();
                Player p1 = new IAPlayer("Pierre", "noir", algo);

                Game g = StandardBuilder
                            .Create()
                                .SetBoard(5)
                                .SetPlayer1(p1)
                                .SetPlayer0(p0)
                            .Build();

                g.CurrentPlayer = 0; // Simulate Human Player Turn
                g.MovePiece(0, 0, 1, 0);
                g.MovePiece(1, 0, 2, 0);
                g.EndTurn();

                // IA turn                
                algo.PlayOneAction(g);
                Thread.Sleep(3000); // simule la réflexion 
                algo.PlayOneAction(g);
                Thread.Sleep(3000);
                algo.PlayOneAction(g);

                
                g.MoveBall(0, 2, 2, 0);
                g.MovePiece(0, 2, 1, 2);
                g.MovePiece(0, 4, 1, 4);

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(g.CommandHistory.Peek().GetCommand().GetType());
                    Console.ReadLine();
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("exception !");
            }
        }
    }
}
