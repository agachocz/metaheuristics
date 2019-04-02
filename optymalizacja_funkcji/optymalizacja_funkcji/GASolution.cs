using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    class GASolution
    {

        uint precision;
        uint length;
        byte[] solution;
        byte zero = 0;
        byte one = 1;
        int min, max;
        public double fitness;
        Random rand;

        public GASolution (int min, int max, uint precision, Random rand)
        {
            this.precision = precision;
            this.min = min;
            this.max = max;

            uint m = 0;
            double size = (max - min) * Math.Pow(10, precision);
            do
            {
                m++;
            } while (size > Math.Pow(2, m) - 1);

            length = m;

            solution = new byte[length];
            this.rand = rand;
        }

        public void initialize ()
        {
            for(int i = 0; i < length; i++)
            {
                solution[i] = rand.NextDouble() < 0.5 ? zero : one;
            }
        }

        public double ToReal()
        {
            double xb = 0;
            for(int i = 0; i < length; i++)
            {
                xb += solution[i] * Math.Pow(2, length - i-1);
            }
            return min+xb*(max - min)/(Math.Pow(2, length)-1);
        }

        public void Evaluate()
        {
            fitness = Problem.Function(this.ToReal());
        }

        public void mutate(double mutProb)
        {
            for(int i = 0; i < length; i++)
            {
                if(rand.NextDouble() < mutProb)
                {
                    //solution[i] = Math.Abs(solution[i] - 1);
                    solution[i] = solution[i] == 1 ? zero : one;
                }
            }
            
        }
    }
}
