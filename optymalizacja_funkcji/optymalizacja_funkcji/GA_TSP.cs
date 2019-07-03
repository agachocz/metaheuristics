using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class GA_TSP
    {
        Solution_TSP[] pop;
        Solution_TSP[] npop;
        int popSize;
        double mutProb;
        double crossProb;
        double cumFitness = 0;
        Random rand;
        int[] r;
        double[] rfit;

        public GA_TSP(int popSize, double mutProb, double crossProb, Random rand)
        {
            pop = new Solution_TSP[popSize];
            npop = new Solution_TSP[popSize];
            this.mutProb = mutProb;
            this.crossProb = crossProb;
            this.popSize = popSize;
            this.rand = rand;

            for (int i = 0; i < popSize; i++)
            {
                pop[i] = new Solution_TSP(rand);
                //Initialization
                pop[i].initialize();
                //Mutation
                pop[i].Mutate(mutProb);
                //Evaluation
                pop[i].Evaluate();
                cumFitness += pop[i].fitness;
            }
        }

        public double Run(int maxIter)
        {
            double bestFitness = double.MaxValue;

            for (int i = 0; i < maxIter; i++)
            {

                cumFitness = 0;
                for (int j = 0; j < popSize-1; j+=2)
                {

                    //selection
                    r = new int[4];
                    
                    do
                    {
                        for(int k = 0; k < 4; k++){
                            r[k] = rand.Next(popSize);
                        }              

                    } while (r[0] == r[1] || r[0] == r[2] || r[0] == r[3] || r[1] == r[2] || r[1] == r[3] || r[2] == r[3]);

                    rfit = new double[4];
                    for(int k = 0; k < 4; k++){
                            rfit[k] = pop[r[k]].fitness;
                        } 
                    Array.Sort(rfit, r);

                    npop[j] = pop[r[0]];
                    npop[j + 1] = pop[r[1]];

                    npop[j].Cross(npop[j + 1], crossProb);

                    //mutation
                    npop[j].Mutate(mutProb);
                    npop[j].Evaluate();

                    npop[j+1].Mutate(mutProb);
                    npop[j+1].Evaluate();
                }

                //If popSize is odd, assign best element from previous iteration to the last element of npop
                if (popSize % 2 == 1)
                {
                    npop[popSize - 1] = pop[r[0]];
                }

                foreach (Solution_TSP s in npop)
                {
                    if (s.fitness < bestFitness) bestFitness = s.fitness;
                }
                //Console.WriteLine("Best fitness in iteration {0} : {1}", i, bestFitness);

                for (int j = 0; j < popSize; j++)
                {
                    pop[j] = npop[j].Clone();
                }
            }


            return bestFitness;
        }
    }
}
