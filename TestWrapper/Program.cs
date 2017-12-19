using System;
using Diaballik;

namespace TestWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var algo = new NoobStrategy();
            var res = algo.playOneAction();
            foreach (var tile in res.Tiles)
                Console.WriteLine(tile); 
            Console.ReadLine();
        }
    }
}
