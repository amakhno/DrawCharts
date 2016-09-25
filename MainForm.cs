using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using Accord.Math;

namespace DrawCharts
{
    public partial class MainForm : Form
    {
        string[] stringDataSource;
        string[] stringDataSource2;
        Double[] x = new Double[] { 0, 2, 5, 9, 10,  6, 2, 2, 0 , 0};
        Double[] y = new Double[] { 0, 0, 1, 3, 10, 10, 9, 6, 2 , 0};
        int iterator = 1;
        double sum = 0;
        Structure4Animation structure;
        int currentPoint = 5;


        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Расстояние между " + stringDataSource[comboBox1.SelectedIndex] + " и " + stringDataSource[comboBox2.SelectedIndex] + " равно " + getDistance(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
        }

        private double getDistance(int indexA, int indexB)
        {            
            return Math.Sqrt( Math.Pow( (x[indexA] - x[indexB]), 2) + Math.Pow((y[indexA] - y[indexB]), 2));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iterator++;
            Series tmp = new Series("Series" + iterator.ToString());
            tmp.ChartType = SeriesChartType.FastLine;
            chart1.Series.Add(tmp);
            chart1.Series["Series" + iterator.ToString()].Points.AddXY(x[comboBox1.SelectedIndex], y[comboBox1.SelectedIndex]);
            chart1.Series["Series" + iterator.ToString()].Points.AddXY(x[comboBox2.SelectedIndex], y[comboBox2.SelectedIndex]);
            sum += getDistance(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
            label4.Text = "Итоговое расстояние = " + sum.ToString();
        }

        private void DrawFigure()
        {
            foreach (Series series in chart1.Series)
            {
                series.ChartType = SeriesChartType.FastLine;
            }
            stringDataSource = new string[y.Length];
            stringDataSource2 = new string[y.Length];

            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(x[i], y[i]);
                stringDataSource[i] = "(" + x[i].ToString() + " ; " + y[i].ToString() + ")";
                stringDataSource2[i] = "(" + x[i].ToString() + " ; " + y[i].ToString() + ")";
            }
            comboBox1.DataSource = stringDataSource;
            comboBox2.DataSource = stringDataSource2;
            return;
        }

        public void DrawFunction()
        {
            chart1.Series[0].Points.Clear();
            for (double x = -Math.PI; x<5000*Math.PI; x+=0.1)
            {
                chart1.Series[0].Points.AddXY(x, function(x));
            }
        }

        private double function(double x)
        {
            return Math.Sin(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x0 = Math.PI-0.1;
            double dx0 = 2;
            double t0 = 0;
            double T = 20;
            double error = 0.01;
            double omega2 = 1;

            DrawDiffUr(x0, dx0, t0, T, error, omega2, (x, y, z) => (-omega2 * Math.Sin(y) - 0.0 * z));
        }

        private void DrawDiffUr(double x0, double dx0, double t0, double T, double error, double omega2, Func<double,double, double, double> MyFunc)
        {
            Result result;
            result = RungeKutta.Solve2(x0,dx0, t0, T, error, MyFunc);
            structure = new Structure4Animation(result.Phi.Length);

            Series tmp = new Series();
            tmp.ChartType = SeriesChartType.FastLine;
            chart1.Series.Add(tmp);
            tmp = new Series();
            tmp.ChartType = SeriesChartType.FastLine;
            chart1.Series.Add(tmp);
            tmp = new Series();
            tmp.ChartType = SeriesChartType.FastLine;
            chart1.Series.Add(tmp);


            double omega = Math.Sqrt(omega2); ;
            double Asmall = dx0 / omega;
            double Bsmall = x0;

            double Bbig = (x0 * omega - dx0) / (2 * omega);
            double Abig = x0 - Bbig;

            for (int i = 0; i<result.Phi.Length; i++)
            {
                double t = t0 + result.h*i;
                //chart1.Series[0].Points.AddXY(t, result.Phi[i]);
                structure.time[i] = t;
                structure.dFunction[i] = result.Phi1[i];
                structure.fucntion[i] = result.Phi[i];

                structure.smallFunction[i] = Asmall * Math.Sin(omega * t) + Bsmall * Math.Cos(omega * t);
                structure.dSmallFunction[i] = Asmall * omega * Math.Cos(omega * t) - Bsmall * omega * Math.Sin(omega * t);

                structure.bigFunction[i] = Abig * Math.Exp(omega * t) + Bbig * Math.Exp(-omega * t);
                structure.dBigFunction[i] = Abig * omega * Math.Exp(omega * t) - Bbig * omega * Math.Exp(-omega * t);

                //structure.bigFunction[i] = 2 * Math.Cosh(omega * t + Math.PI / 2);
                //structure.dBigFunction[i] = 2 * omega *  Math.Sinh(omega * t + Math.PI / 2);

                //chart1.Series[0].Points.AddXY(structure.fucntion[i], structure.dFunction[i]);
                //chart1.Series[1].Points.AddXY(structure.smallFunction[i], structure.dSmallFunction[i]);
            }

            chart1.ChartAreas[0].Axes[0].Maximum = result.Phi.Max();
            chart1.ChartAreas[0].Axes[1].Maximum = result.Phi1.Max()+1;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();


            timer1.Enabled = true;

            //DrawPhasePortrait(result);           
        }

        private void DrawPhasePortrait(Result result)
        {
            //Series tmp = new Series();
            //tmp.ChartType = SeriesChartType.FastLine;
            //chart1.Series.Clear();
            //chart1.Series.Add(tmp); 
            for(int i = 0; i<result.Phi.Length;i++)
            {
                chart1.Series[0].Points.AddXY(result.Phi[i], result.Phi1[i]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentPoint++;
            chart1.Series[0].Points.AddXY(structure.fucntion[currentPoint], structure.dFunction[currentPoint]);
            chart1.Series[1].Points.AddXY(structure.smallFunction[currentPoint], structure.dSmallFunction[currentPoint]);
            chart1.Series[2].Points.AddXY(structure.bigFunction[currentPoint], structure.dBigFunction[currentPoint]);
            if (currentPoint == (structure.time.Length - 1)) timer1.Enabled = false; 



        }
    }
}
