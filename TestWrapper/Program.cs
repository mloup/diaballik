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
                Player p1 = new HumanPlayer("Marie", "rouge");
                var algo = new NoobStrategy();
                Player p0 = new IAPlayer("Pierre", "noir", algo);

                Game.INSTANCE = StandardBuilder.Create().SetBoard(7).SetPlayer1(p1).SetPlayer0(p0).SetHasIA(true).Build();
                
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
