using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vertezml
{
    public static class stdevOp
    {
        public static double stdev(List<double> x)
        {
            int elements;
            double mean;
            double sqrdSum = 0;
            double sum = 0;
            for(elements = 0; elements < x.Count; elements++)
            {
                sum += x[elements];
            }
            mean = sum / x.Count;
            for(elements = 0; elements < x.Count; elements++)
            {
                double diff = x[elements] - mean;
                double powDiff = Math.Pow(diff, 2);
                sqrdSum += powDiff;
            }
            double calc = sqrdSum / x.Count;
            double stdOut = Math.Sqrt(calc);
            return stdOut;
        }
    }
}
