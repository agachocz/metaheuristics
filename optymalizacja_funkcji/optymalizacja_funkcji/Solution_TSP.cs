using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class Solution_TSP
    {
        uint precision;
        uint length;
        int[] solution;
        public double fitness;
        Random rand;

        public Solution_TSP(uint precision, Random rand)
        {
            this.precision = precision;
            solution = new int[ProblemTSP.n];
            this.rand = rand;
        }

        public void initialize()
        {
            for (int i = 0; i < ProblemTSP.n; i++)
            {
                solution[i] = i;
            }
            for (int i = 0; i < ProblemTSP.n * ProblemTSP.n; i++)
            {
                this.Swap();
            }
        }

        public void Swap()
        {
            int p1 = rand.Next(ProblemTSP.n);
            int p2;
            do
            {
                p2 = rand.Next(ProblemTSP.n);
            } while (p1 == p2);

            int temp = solution[p1];
            solution[p1] = solution[p2];
            solution[p2] = temp;
        }

        public void Mutate(double mutProb)
        {
            if(rand.NextDouble() < mutProb)
            {
                Swap();
            }
        }


        public void Evaluate()
        {
            fitness = ProblemTSP.Function(solution);
        }

        public Solution_TSP Clone()
        {
            Solution_TSP clone = (Solution_TSP)this.MemberwiseClone();
            clone.solution = (int[])this.solution.Clone();
            return clone;
        }
    }
}
