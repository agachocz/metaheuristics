using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class GA
    {
        GASolution[] pop;
        double mutProb;

        public GA(int popSize, int maxGen, double mutProb, Random rand)
        {
            pop = new GASolution[popSize];
            this.mutProb = mutProb;

            foreach (GASolution s in pop)
            {
                //Initialization
                s.initialize();
                //Mutation
                s.mutate(mutProb);
                //Evaluation
                s.Evaluate();
            }
        }

        public void Run (int maxIter)
        {
            double bestFitness = double.MinValue;

            foreach(GASolution s in pop)
            {
                if (s.fitness > bestFitness) bestFitness = s.fitness;
            }
        }

        
            
     }
   
}
