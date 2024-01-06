using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vertezml
{
    public static class MedianOp
    {
        public static double Median(List<double> values) {
            int elements;
            double outVal;
            double min = values[0];
            List<double> res = new List<double>();
            for(elements = 0; elements < values.Count; elements++)
            {
                if (min < values[elements])
                {
                    res.Add(values[elements]);
                }
                else
                {
                    res.Add(min);
                    min = values[elements];
                }
            }
            if(res.Count % 2 != 0)
            {
                int index = (int)(res.Count / 2);
                outVal = res[index];
            }
            else
            {
                int index = (int)(res.Count / 2);
                int firstIndex = (int)res[index - 1];
                int secondIndex = (int)res[index];
                outVal = (int)(firstIndex + secondIndex) / 2;
            }
            //Console.WriteLine($"Median: {outVal}");
            return outVal;
        }
    }
}
