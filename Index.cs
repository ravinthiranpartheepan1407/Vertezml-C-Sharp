using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vertezml
{
    public static class Module
    {
        public static double Mean(List<double> values)
        {
            return MeanOp.CalculateMean(values);
        }
    }
}
