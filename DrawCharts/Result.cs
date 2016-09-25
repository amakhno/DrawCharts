using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawCharts
{
    public class Result
    {
        public double[] Phi;
        public double[] Phi1;

        public double h;

        public double PreviousPhi;

        public double absError;
        public double Error;

        public Result(int N)
        {
            Phi = new double[N];
            Phi1 = new double[N];
        }

        public bool Check(double error, Result PreviousResult)
        {
            double sum1 = 0;
            double sum2 = 0;
            for (int i = 0; i<PreviousResult.Phi.Length; i++)
            {
                sum1 += Math.Abs(PreviousResult.Phi[i]);
            }
            for (int i = 0; i < Phi.Length; i++)
            {
                sum2 += Math.Abs(Phi[i]);
            }
            absError = Math.Abs(sum1/PreviousResult.Phi.Length - sum2/Phi.Length);
            Error = absError / (sum1/PreviousResult.Phi.Length);
            if (absError>error) return false;
            return true;
        }
    }
}
