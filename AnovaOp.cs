using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vertezml
{
    public static class AnovaOp
    {
        public struct AnovaOut
        {
            public double sswgOut;
            public double tssOut;
            public double anovaRes;
        };

        public static AnovaOut Anova(List<double> x, List<double> y)
        {
        double sumX = 0.0, sumY = 0.0, meanX, meanY, xSSWG = 0.0, ySSWG = 0.0, xObsVal = 0.0, yObsVal = 0.0;
        //List<double> res = new List<double>();
        int elements;
            
        for(elements = 0; elements < x.Count; elements++)
            {
                sumX += x[elements];
                sumY += y[elements];
            }
            meanX = sumX / x.Count;
            meanY = sumY / y.Count;

            // Calculate Sum of Squares within groups (SSWG)
            for(elements = 0; elements < x.Count; elements++)
            {
                double diff = x[elements] - meanX;
                double sqr = Math.Pow(diff, 2);
                xSSWG += sqr;
            }
            for(elements = 0; elements < y.Count; elements++)
            {
                double diff = y[elements] - meanY;
                double sqr = Math.Pow(diff, 2);
                ySSWG += sqr;
            }

            double sswg = xSSWG + ySSWG;

            // Total Sum of Squares (TSS)
            double sizeXY = x.Count + y.Count;
            double meanObs = (sumX + sumY) / sizeXY;
            for(elements = 0; elements < x.Count; elements++)
            {
                double xObs = x[elements] - meanObs;
                double sqr = Math.Pow(xObs, 2);
                xObsVal += sqr;
            }
            for(elements = 0; elements < y.Count; elements++)
            {
                double yObs = y[elements] - meanObs;
                double sqr = Math.Pow(yObs, 2);
                yObsVal += sqr;
            }
            
            double tss = xObsVal + yObsVal;

            // Calculate Sum of Squares between groups
            // Sum of Squares between groups = Total sum of squares - Sum of squares within groups
            double xMeanSSBG = meanX - meanObs;
            // cout<<"xMeanSSBG: "<<meanXVal<<" - "<<meanTotObs<<": "<<xMeanSSBG<<endl;
            double yMeanSSBG = meanY - meanObs;
            // cout<<"yMeanSSBG: "<<meanYVal<<" - "<<meanTotObs<<": "<<yMeanSSBG<<endl;
            double ssBG = (Math.Pow(xMeanSSBG, 2) + Math.Pow(yMeanSSBG, 2)) * x.Count;

            // degress of freedom - 1 which is (total no.of groups) - 1
            // a = Sum of Squares between group / degrees of freedom 
            double finalSSBG = ssBG / 1;

            // degrees of freedom = total observations - total no.of groups
            // b = Sum of squares within groups / degrees of freedom
            double finalSSWG = sswg / ((x.Count + y.Count) - 3);
            double outVal = (double)finalSSBG / finalSSWG;
            // Refer F-Statistics
            // Consider degrees of freedom from numerator from Horizontal perspective which is SSBG
            // Consider degrees of freedom from numerator from Vertical perspective which is SSWG
            // In this case the degrees of freedom in horizontal perspective is 1 (Groups - 1)
            // In this case the degrees of freedom in horizontal perspective is 7 (Total observations - 3)
            AnovaOut anovaOut;
            anovaOut.sswgOut = sswg;
            anovaOut.tssOut = tss;
            anovaOut.anovaRes = outVal;
            return anovaOut;
        }
    }
}
