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

                Game.INSTANCE = StandardBuilder.Create().SetBoard(3).SetPlayer1(p1).SetPlayer0(p0).Build();
                
                NoobStrategy.Command res = algo.PlayOneAction();
                Console.WriteLine(res);
                Console.ReadLine();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("exception !");
            }
        }
    }
}
