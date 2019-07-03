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

/*
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
            */

            //TSP

            Problem_TSP problem = new Problem_TSP();
            problem.ReadProblem("TSP30.txt");
            GA_TSP ga_tsp;


            for (int i = 0; i < sampSize; i++)
            {
                ga_tsp = new GA_TSP(50, 0.1, 0.8, rand);
                results[0, i] = ga_tsp.Run(50);

                ga_tsp = new GA_TSP(50, 0.3, 0.8, rand);
                results[1, i] = ga_tsp.Run(50);

                ga_tsp = new GA_TSP(50, 0.1, 0.5, rand);
                results[2, i] = ga_tsp.Run(50);

                ga_tsp = new GA_TSP(25, 0.1, 0.8, rand);
                results[3, i] = ga_tsp.Run(100);

                ga_tsp = new GA_TSP(100, 0.1, 0.8, rand);
                results[4, i] = ga_tsp.Run(25);

            }

            try
            {

                FileStream fileStream = File.Open("TSP_results.txt", FileMode.Create, FileAccess.Write);
                StreamWriter fileWriter = new StreamWriter(fileStream);
                fileWriter.WriteLine("basic;highMutProb;lowCrossProb;moreIter;bigPop;");

                for (int i = 0; i < sampSize; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        fileWriter.Write(results[j, i] + ";");
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


        }

        
    }
}
