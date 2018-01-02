using System;
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

                Game g = StandardBuilder.Create().SetBoard(3).SetPlayer1(p1).SetPlayer0(p0).Build();
                
                algo.PlayOneAction(g);

                Console.WriteLine(g.CommandHistory.Peek().GetCommand().GetType());
                Console.ReadLine();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("exception !");
            }
        }
    }
}
