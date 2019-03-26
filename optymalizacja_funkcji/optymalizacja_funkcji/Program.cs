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

            //double result = RandomSearch.Run(300, rand);
            //Console.WriteLine("Random search: " + result);


            //double result2 = HillClimbing.Run(300, rand);
            //Console.WriteLine("Hill climbing: " + result2);

            //double result3 = TabooSearch.Run(300, rand, 3);
            //Console.WriteLine("Taboo search: " + result3);
            //Console.ReadKey();

            GA ga = new GA(50, 10, 0.1, rand);
            double result4 = ga.Run(300);
            Console.WriteLine("Genetic algorithm: " + result4);
            Console.ReadKey();

            SimulatedAnnealing sa = new SimulatedAnnealing(-1, 2, 6, rand);
            double result5 = sa.Run(300, 0.0002, rand);
            Console.WriteLine("Simulated annealing: " + result5);
            Console.ReadKey();

            //Console.ReadKey();
        }
    }
}
