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

                Game g = StandardBuilder.Create().SetBoard(5).SetPlayer1(p1).SetPlayer0(p0).Build();
                g.CurrentPlayer = 0; // Au tour du joueur humain
                MovePiece mp = new MovePiece(4, 4, 3, 4);
                mp.Do(g);
                mp = new MovePiece(3, 4, 2, 4);
                mp.Do(g);

                
                algo.PlayOneAction(g);
                Thread.Sleep(3000); // simule la réflexion 
                algo.PlayOneAction(g);
                Thread.Sleep(3000);
                algo.PlayOneAction(g);

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
