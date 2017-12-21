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
                var algo = new NoobStrategy();
                var res = algo.PlayOneAction();
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
