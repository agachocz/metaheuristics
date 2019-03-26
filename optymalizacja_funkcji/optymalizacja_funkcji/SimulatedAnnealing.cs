using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    using p = Problem;

    class SimulatedAnnealing
    {

        Solution s, ns;

        public SimulatedAnnealing(int min, int max, uint precision, Random rand)
        {
            s = new Solution(min, max, precision, rand);
            s.Evaluate();
        }

        public double Run (int maxIter, double temp, Random rand)
        {
            
            for(int i = 0; i < maxIter; i++)
            {
                ns = s.Clone();
                ns.mutate(0.1);
                ns.Evaluate();

                double diff = ns.fitness - s.fitness;
                if (ns.fitness > s.fitness)
                {
                    s = ns;
                }
                else if (rand.NextDouble() < Math.Exp(diff/temp))
                {
                    s = ns;
                }
            }

            return s.fitness;
        }
    }
}
