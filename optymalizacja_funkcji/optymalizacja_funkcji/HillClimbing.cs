using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optymalizacja_funkcji
{
    using p = Problem;

    class HillClimbing
    {
        public static double Run(int maxIter, Random rand)
        {
            double dev = 0.3;

            double max = double.MinValue;
          

                double x = rand.NextDouble() * 3 - 1;
                double y = p.Function(x);

                double xLeft = x - Math.Abs(p.Normal(0, dev));
                if (xLeft < -1) xLeft = -1;

                double xRight = x + Math.Abs(p.Normal(0, dev));
                if (xRight > 2) xRight = 2;

                double yLeft = p.Function(xLeft);
                double yRight = p.Function(xRight);

                maxIter -= 3;

                    if (yLeft > y)
                    {
                        do {
                            x = xLeft;
                            y = yLeft;
                            maxIter--;

                            xLeft = x - Math.Abs(p.Normal(0, dev));
                            if (xLeft < -1) xLeft = -1;
                            yLeft = p.Function(xLeft);

                        } while (yLeft > y && maxIter > 0);

                    }
                    else if (yRight > y)
                    {
                        do {
                            x = xRight;
                            y = yRight;
                            maxIter--;

                            xRight = x + Math.Abs(p.Normal(0, dev));
                            if (xRight > 2) xRight = 2;
                            yRight = p.Function(xRight); 

                        } while (yRight > y && maxIter > 0);
                        
                    }

                if (y > max) max = y;

            return max;
        }
    



    }
}
