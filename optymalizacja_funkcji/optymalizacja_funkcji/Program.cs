using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using stats = MathNet.Numerics.Statistics.Statistics;

namespace optymalizacja_funkcji
{
    public class Program
    {


        static void Main(string[] args)
        {
            Random rand = new Random();
            int sampSize = 30;
            double[,] results = new double[5, sampSize];


            for (int i = 0; i < sampSize; i++)
            {
                results[0,i] = RandomSearch.Run(1000, rand);
                results[1,i] = HillClimbing.Run(1000, rand);
                results[2,i] = TabooSearch.Run(1000, rand, 4);
                GA ga = new GA(20, 10, 0.05, rand);
                results[3,i] = ga.Run(50);
                SimulatedAnnealing sa = new SimulatedAnnealing(-1, 2, 6, rand);
                results[4,i] = sa.Run(1000, 20, rand);
            }

            try
            {

                FileStream fileStream = File.Open("meta_results.txt", FileMode.Create, FileAccess.Write);
                StreamWriter fileWriter = new StreamWriter(fileStream);
                fileWriter.WriteLine("randSearch;hillClimb;taboo;ga;sa;");

                for (int i = 0; i < sampSize; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        fileWriter.Write(results[j,i]+";");
                    }
                    fileWriter.WriteLine("");
                }
                    
                fileWriter.Flush();
                fileWriter.Close();
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe);
            }


            //ProblemTSP problem = new ProblemTSP();
            //problem.ReadProblem("TSP30.txt");
            //GA_TSP ga_tsp = new GA_TSP(20, 10, 0.1, rand);
            //ga_tsp.Run(50);
            //Console.ReadKey();

        }
    }
}
