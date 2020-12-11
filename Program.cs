using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicativeModel
{
    class Program
    {
        static void Main(string[] args)
        {
            double queueSize = 200;

            double dispersionRatio = 100;
            double z = 100;

            double n = Math.Pow(dispersionRatio, 1 / z);

            List<double> values = new List<double>();


            for (int i = 0; i < z; i++)
            {
                values.Add(Math.Pow(n, i));
            }


            double sum = values.Sum();

            Console.WriteLine("ratio sum: " + sum);
            double XInequation = queueSize / sum; //GetFactorRatio(



            List<double> absolutCount = new List<double>();

            foreach (double val in values)
            {
                absolutCount.Add(val * XInequation);
            }

            ShowResult(absolutCount);


            Console.Read();
        }

        public static void ShowResult(List<double> values)
        {
            foreach (var val in values)
                Console.WriteLine(val);

            Console.WriteLine("Avverage: " + GetAvverage(values));
            Console.WriteLine("Disperion: " + GetDisperion(values));
            Console.WriteLine("Standard deviation: " + Math.Sqrt(GetDisperion(values)));

            Console.WriteLine();

            double countSum = values.Sum();

            Console.WriteLine("count sum: " + countSum);
        }

        public static double GetAvverage(List<double> values)
        {
            return values.Sum() / values.Count;
        }

        public static double GetDisperion(List<double> values)
        {
            return GetAvverage(values.Select(v => Math.Pow(v, 2)).ToList()) - Math.Pow(GetAvverage(values), 2);
        }

        /// <summary>
        ///  В случае большой конкуренции базовый коэффициент настолько мал, что не представляет собой целой число, 
        ///  а количество минимальной очереди равно сумме чисел арифметической прогрессии с шагом 1/advCount 
        ///  от a1 до an, но при целом значении базового коэффициента, определяющего поправку
        /// </summary>
        /// <param name="factor">используй GetBaseFactor</param>
        /// <param name="factorRatio">определяет число, на которое нужно умножить коэффициент, чтобы получить базовый коэффициент для
        /// поправки</param>
        /// <returns></returns>
        public static (double val, int factorRatio) GetFactorRatio(double factor, int factorRatio = 0)
        {
            if (factor < 1)
            {
                factorRatio++;
                factor *= 10;
            }
            else
                return (factor, factorRatio);
            return GetFactorRatio(factor, factorRatio);
        }
    }
}
