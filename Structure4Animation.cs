using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DrawCharts
{
    class Structure4Animation
    {
        public double[] fucntion;
        public double[] dFunction;

        public double[] dBigFunction;
        public double[] bigFunction;

        public double[] dSmallFunction;
        public double[] smallFunction;

        public double[] time;

        public Structure4Animation(int size)
        {
            fucntion = new double[size];
            dFunction = new double[size];
            time = new double[size];
            dBigFunction = new double[size];
            bigFunction = new double[size];
            dSmallFunction = new double[size];
            smallFunction = new double[size];
        }
    }
}
