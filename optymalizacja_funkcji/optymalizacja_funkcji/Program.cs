using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    public class Program
    {

        static void Main(string[] args)
        {
            Random rand = new Random();

            double result = RandomSearch.Run(300, rand);
            Console.WriteLine("Random search: " + result);
        

            double result2 = HillClimbing.Run(300, rand);
            Console.WriteLine("Hill climbing: " + result2);

            double result3 = TabooSearch.Run(300, rand, 4);
            Console.WriteLine("Taboo search: " + result3);
            Console.ReadKey();
        }
    }
}
