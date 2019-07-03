using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace optymalizacja_funkcji
{
    class Problem_TSP
    {
        public static int n; //nr of towns
        static int bestResult;
        static int[,] points;

        public void ReadProblem(string file)
        {
            string[] lines = File.ReadAllLines(file);
            n = int.Parse(lines[0]);
            bestResult = int.Parse(lines[1]);
            points = new int[n, 2];

            for (int i = 0; i < n; i++)
            {
                string[] s = lines[2 + i].Split(' ');
                points[i, 0] = int.Parse(s[0]);
                points[i, 1] = int.Parse(s[1]);
            }
        }

        public static int Function(int[] path)
        {
            int result = 0;
            for (int i = 0; i < n - 1; i++)
            {
                result += (int)(Math.Sqrt(Math.Pow(points[path[i], 0] - points[path[i + 1], 0], 2) + Math.Pow(points[path[i], 1] - points[path[i + 1], 1], 2)) + 0.51);
            }

            result += (int)(Math.Sqrt(Math.Pow(points[path[n - 1], 0] - points[path[0], 0], 2) + Math.Pow(points[path[n - 1], 1] - points[path[0], 1], 2)) + 0.51);

            return result;
        }
    }
}
