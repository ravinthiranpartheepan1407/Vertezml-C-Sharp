using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vertezml
{
    public static class MeanOp
    {
        public static double CalculateMean(List<double> values)
        {
            int elements;
            double sum = 0;
            for(elements = 0; elements < values.Count; elements++)
            {
                sum += values[elements];
            }
            double res = sum / values.Count;
            //Console.WriteLine(res);
            return res;
        }
    }
}