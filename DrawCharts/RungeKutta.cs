using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawCharts
{
    public static class RungeKutta
    {
        /*/// <summary>
        /// Текущее время
        /// </summary>
        public double t;
        /// <summary>
        /// Искомое решение Y[0] - само решение, Y[i] - i-тая производная решения
        /// </summary>
        public double[] Y;
        /// <summary>
        /// Внутренние переменные 
        /// </summary>
        double[] YY, Y1, Y2, Y3, Y4;
        protected double[] FY;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="N">размерность системы</param>
        public RungeKutta(uint N)
        {
            Init(N);
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        public RungeKutta() { }
        /// <summary>
        /// Выделение памяти под рабочие массивы
        /// </summary>
        /// <param name="N">Размерность массивов</param>
        protected void Init(uint N)
        {
            Y = new double[N];
            YY = new double[N];
            Y1 = new double[N];
            Y2 = new double[N];
            Y3 = new double[N];
            Y4 = new double[N];
            FY = new double[N];
        }
        /// <summary>
        /// Установка начальных условий
        /// </summary>
        /// <param name="t0">Начальное время</param>
        /// <param name="Y0">Начальное условие</param>
        public void SetInit(double t0, double[] Y0)
        {
            t = t0;
            if (Y == null)
                Init((uint)Y0.Length);
            for (int i = 0; i < Y.Length; i++)
                Y[i] = Y0[i];
        }
        /// <summary>
        /// Расчет правых частей системы
        /// </summary>
        /// <param name="t">текущее время</param>
        /// <param name="Y">вектор решения</param>
        /// <returns>правая часть</returns>
        abstract public double[] F(double t, double[] Y);
        /// <summary>
        /// Следующий шаг метода Рунге-Кутта
        /// </summary>
        /// <param name="dt">текущий шаг по времени (может быть переменным)</param>
        public void NextStep(double dt)
        {
            int i;

            if (dt < 0) return;

            // рассчитать Y1
            Y1 = F(t, Y);

            for (i = 0; i < Y.Length; i++)
                YY[i] = Y[i] + Y1[i] * (dt / 2.0);

            // рассчитать Y2
            Y2 = F(t + dt / 2.0, YY);

            for (i = 0; i < Y.Length; i++)
                YY[i] = Y[i] + Y2[i] * (dt / 2.0);

            // рассчитать Y3
            Y3 = F(t + dt / 2.0, YY);

            for (i = 0; i < Y.Length; i++)
                YY[i] = Y[i] + Y3[i] * dt;

            // рассчитать Y4
            Y4 = F(t + dt, YY);

            // рассчитать решение на новом шаге
            for (i = 0; i < Y.Length; i++)
                Y[i] = Y[i] + dt / 6.0 * (Y1[i] + 2.0 * Y2[i] + 2.0 * Y3[i] + Y4[i]);

            // рассчитать текущее время
            t = t + dt;
        }*/

        /// <summary>
        /// Решение дифференциального уравнения второго порядка
        /// </summary>
        /// <param name="x0">значение функции в t0</param>
        /// <param name="x1">значение производной в t0</param>
        /// <param name="begin">значение t0</param>
        /// <param name="end">значение T</param>
        /// <param name="end">Шаг</param>
        /// <param name="MyFunc">Функция</param>
        /// <returns>правая часть</returns>
        //    public static Result Solve2(double x0, double x1, double begin, double end, double error, Func<double, double, double, double> MyFunc)
        //    {
        //        double Xo, Yo, Y1, Zo, Z1;
        //        double k1, k2, k4, k3, h;
        //        double q1, q2, q4, q3;
        //        /*
        //         *Начальные условия
        //         */
        //        Xo = begin;
        //        Yo = x0;
        //        Zo = x1;

        //        h = 0.001; // шаг

        //        Result result; //Класс возвращаемых данных
        //        int Size = (int)Math.Ceiling((end - begin) / h);
        //        result = new Result(Size);
        //        double middle = 999;

        //        /*do
        //        {*/
        //            for (int i = 0; i < Size; i++)
        //            {

        //                k1 = h * MyFunc(Xo, Yo, Zo);
        //                q1 = h * g(Xo, Yo, Zo);

        //                k2 = h * MyFunc(Xo + h / 2.0, Yo + q1 / 2.0, Zo + k1 / 2.0);
        //                q2 = h * g(Xo + h / 2.0, Yo + q1 / 2.0, Zo + k1 / 2.0);

        //                k3 = h * MyFunc(Xo + h / 2.0, Yo + q2 / 2.0, Zo + k2 / 2.0);
        //                q3 = h * g(Xo + h / 2.0, Yo + q2 / 2.0, Zo + k2 / 2.0);

        //                k4 = h * MyFunc(Xo + h, Yo + q3, Zo + k3);
        //                q4 = h * g(Xo + h, Yo + q3, Zo + k3);

        //                Z1 = Zo + (k1 + 2.0 * k2 + 2.0 * k3 + k4) / 6.0;
        //                Y1 = Yo + (q1 + 2.0 * q2 + 2.0 * q3 + q4) / 6.0;

        //                result.Phi[i] = Y1;
        //                result.Phi1[i] = Z1;

        //                Yo = Y1;
        //                Zo = Z1;
        //                Xo += h;
        //            }

        //            /*h /= 2;
        //            if (result.Check(error, middle)) break;
        //            middle = result.Phi[result.Phi.Length/2];

        //            Size = (int)Math.Ceiling((end - begin) / h);
        //            result = new Result(Size);
        //        }
        //        while (true);*/
        //        return result;
        //    }

        //    


        public static Result Solve2(double x0, double x1, double begin, double end, double error, Func<double, double, double, double> MyFunc)
        {
            double Xo, Yo, Y1, Zo, Z1;
            double k1, k2, k4, k3, h;
            double q1, q2, q4, q3;

            //Начальные условия

            Xo = begin;
            Yo = x0;
            Zo = x1;

            h = 0.1; // шаг

            int Size = (int)Math.Ceiling((end - begin) / h);
            Result result = new Result(Size);

            Result PreviousResult = new Result(1);
            PreviousResult.Phi[0] = 100000;

            do
            {
                Size = (int)Math.Ceiling((end - begin) / h);
                result = new Result(Size);

                Xo = begin;
                Yo = x0;
                Zo = x1;
                Y1 = 0; Z1 = 0;
                k1 = 0; k2 = 0; k4 = 0; k3 = 0;
                q1 = 0; q2 = 0; q4 = 0; q3 = 0;

                for (int i = 0; i < Size; i++)
                {

                    k1 = h * MyFunc(Xo, Yo, Zo);
                    q1 = h * g(Xo, Yo, Zo);

                    k2 = h * MyFunc(Xo + h / 2.0, Yo + q1 / 2.0, Zo + k1 / 2.0);
                    q2 = h * g(Xo + h / 2.0, Yo + q1 / 2.0, Zo + k1 / 2.0);

                    k3 = h * MyFunc(Xo + h / 2.0, Yo + q2 / 2.0, Zo + k2 / 2.0);
                    q3 = h * g(Xo + h / 2.0, Yo + q2 / 2.0, Zo + k2 / 2.0);

                    k4 = h * MyFunc(Xo + h, Yo + q3, Zo + k3);
                    q4 = h * g(Xo + h, Yo + q3, Zo + k3);

                    Z1 = Zo + (k1 + 2.0 * k2 + 2.0 * k3 + k4) / 6.0;
                    Y1 = Yo + (q1 + 2.0 * q2 + 2.0 * q3 + q4) / 6.0;

                    result.Phi[i] = Y1;
                    result.Phi1[i] = Z1;

                    Yo = Y1;
                    Zo = Z1;
                    Xo += h;
                }

                if (result.Check(error, PreviousResult)) break;
                h /= 2;



                PreviousResult = result;
        } while (true);
            result.h = h;
            return result;
        }
        public static double g(double x, double y, double z)
        {
            return (z);
        }
    }
}
