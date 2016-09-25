using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawCharts
{
    class TMyRK 
    {
        /*public TMyRK(uint N) { Init(N); }

        /// <summary>
        /// пример математический маятник 
        /// y''(t)+y(t)=0
        /// </summary>
        /// <param name="t">Время</param>
        /// <param name="Y">Решение</param>
        /// <returns>Правая часть</returns>
        public override double[] F(double t, double[] Y)
        {
            FY[0] = Y[1];
            FY[1] = -Y[0];
            return FY;
        }
        /// <summary>
        /// Пример использования
        /// </summary>
        static public List<double> Test()
        {
            List<double> result = new List<double>();
            // Шаг по времени
            double dt = 0.001;
            // Объект метода
            TMyRK task = new TMyRK(2);
            // Определим начальные условия y(0)=0, y'(0)=1 задачи
            double[] Y0 = { 0, 1 };
            // Установим начальные условия задачи
            task.SetInit(0, Y0);
            // решаем до 15 секунд
            while (task.t <= 15)
            {
                //Console.WriteLine("Time = {0:F5}; Func = {1:F8};  d Func / d x = {2:F8}", task.t, task.Y[0], task.Y[1]); // вывести t, y, y'
                // рассчитать на следующем шаге, шаг интегрирования 
                result.Add(Y0[0]);
                task.NextStep(dt);
            }
            return result;
            //Console.ReadLine();
        }
        */
    }
}
