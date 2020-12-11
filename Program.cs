using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicativeModel
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 10;
            double z = 10;

            double n = Math.Pow(x, 1 / z);

            List<double> values = new List<double>();


            for (int i = 0; i < z; i++)
            {
                values.Add(Math.Pow(n, i));
            }



            foreach (var val in values)
                Console.WriteLine(val);


            Console.WriteLine("Avverage: " + GetAvverage(values));
            Console.WriteLine("Disperion: " + GetDisperion(values));
            Console.WriteLine("Standard deviation: " + Math.Sqrt(GetDisperion(values)));
            Console.Read();
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
