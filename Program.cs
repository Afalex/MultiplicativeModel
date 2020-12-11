using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicativeModel
{
    class Program
    {
        static void Main(string[] args)
        {

            double z = 10;

            double maxCountForMember = z* 2  + z * 0.5;
        //    double queueSize = GetQueueSize((int)z);

            double n = Math.Pow(maxCountForMember, 1 / z);


            List<double> values = new List<double>();


            for (int i = 0; i < z; i++)
            {
                values.Add(Math.Pow(n, i));
            }


            double sum = values.Sum();

            Console.WriteLine("ratio sum: " + sum);
            double XInequation = 1; //queueSize / sum;

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

    }
}
