using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class Solution_TSP
    {
        uint length;
        public int[] solution;
        public double fitness;
        Random rand;

        public Solution_TSP(Random rand)
        {
            solution = new int[Problem_TSP.n];
            this.rand = rand;
        }

        public void initialize()
        {
            for (int i = 0; i < Problem_TSP.n; i++)
            {
                solution[i] = i;
            }
            for (int i = 0; i < Problem_TSP.n * Problem_TSP.n; i++)
            {
                this.Swap();
            }
        }

        public void Swap()
        {

            int p1 = rand.Next(Problem_TSP.n);
            int p2;
            do
            {
                p2 = rand.Next(Problem_TSP.n);
            } while (p1 == p2);

            int temp = solution[p1];
            solution[p1] = solution[p2];
            solution[p2] = temp;
        }

        public void Mutate(double mutProb)
        {
            if (rand.NextDouble() < mutProb)
            {
                Swap();
            }
        }

        public void Cross(Solution_TSP r1, double crossProb)
        {
            if (rand.NextDouble() < crossProb)
            {
                Solution_TSP c1 = new Solution_TSP(rand);
                c1.solution = Enumerable.Repeat(-1, Problem_TSP.n).ToArray();
                Solution_TSP c2 = new Solution_TSP(rand);
                c2.solution = Enumerable.Repeat(-1, Problem_TSP.n).ToArray();

                int np = rand.Next((int)Problem_TSP.n);

                for (int i = 0; i < np; i++)
                {
                    int p = rand.Next((int)Problem_TSP.n);
                    c1.solution[p] = this.solution[p];
                    c2.solution[p] = r1.solution[p];
                }

                int p1 = 0, p2 = 0;
                for (int i = 0; i < Problem_TSP.n; i++)
                {
                    if (c1.solution[i] == -1)
                    {
                        while (c1.solution.Contains(this.solution[p1])) p1++;
                        c1.solution[i] = this.solution[p1];
                    }
                    if (c2.solution[i] == -1)
                    {
                        while (c2.solution.Contains(r1.solution[p2])) p2++;
                        c2.solution[i] = r1.solution[p2];
                    }
                }

                this.solution = c1.solution;
                r1.solution = c2.solution;

            }

        }


        public void Evaluate()
        {
            this.fitness = Problem_TSP.Function(solution);
        }

        public Solution_TSP Clone()
        {
            Solution_TSP clone = (Solution_TSP)this.MemberwiseClone();
            clone.solution = (int[])this.solution.Clone();
            return clone;
        }
    }
}
