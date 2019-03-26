using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class GA
    {
        Solution[] pop;
        int popSize;
        double mutProb;
        double cumFitness = 0;
        Random rand;

        public GA(int popSize, int maxGen, double mutProb, Random rand)
        {
            pop = new Solution[popSize];
            this.mutProb = mutProb;
            this.popSize = popSize;
            this.rand = rand;

            for(int i=0; i<popSize; i++)
            {
                pop[i] = new Solution(-1, 2, 6, rand);
                //Initialization
                pop[i].initialize();
                //Mutation
                pop[i].mutate(mutProb);
                //Evaluation
                pop[i].Evaluate();
                cumFitness += pop[i].fitness;
            }
        }

        public double Run (int maxIter)
        {
            double bestFitness = double.MinValue;

            for(int i=0; i<maxIter; i++)
            {
                
                Solution[] npop = new Solution[popSize];
                for(int j=0; j<popSize; j++)
                {

                    //selection
                    int r1 = rand.Next(popSize);
                    int r2;
                    do {
                        r2 = rand.Next(popSize);
                    } while (r1 == r2);

                    npop[j] = pop[r1].fitness > pop[r2].fitness ? pop[r1].Clone() : pop[r2].Clone();
                    //mutation
                    npop[j].mutate(mutProb);
                    npop[j].Evaluate();
                }

                //cross
                for(int j=0; j<popSize-1; j+=2)
                {
                    npop[j].CrossOver(npop[j + 1], 0.9);
                }

                for (int j = 0; j < popSize - 1; j += 2)
                {
                    pop[j] = npop[j];
                }

                foreach (Solution s in pop)
                    {
                        if (s.fitness > bestFitness) bestFitness = s.fitness;
                    }

            }


            return bestFitness;
        }

        
            
     }
   
}
