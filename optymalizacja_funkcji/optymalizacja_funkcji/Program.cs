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

            double result = RandomSearch.Run(1000, rand);
            Console.WriteLine("Random search: " + result);

            double result2 = HillClimbing.Run(1000, rand);
            Console.WriteLine("Hill climbing: " + result2);

            double result3 = TabooSearch.Run(1000, rand, 3);
            Console.WriteLine("Taboo search: " + result3);        

            GA ga = new GA(20, 10, 0.1, rand);
            double result4 = ga.Run(50);
            Console.WriteLine("Genetic algorithm: " + result4);

            SimulatedAnnealing sa = new SimulatedAnnealing(-1, 2, 6, rand);
            double result5 = sa.Run(1000, 0.0002, rand);
            Console.WriteLine("Simulated annealing: " + result5);
            Console.ReadKey();

        }
    }
}
