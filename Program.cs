using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicativeModel
{
    class Program
    {
        static void Main(string[] args)
        {
            double membersCount = 100;
            const double DISPERSION_LEVEL = 2.5;
            double maxCountForMember = membersCount * DISPERSION_LEVEL; //максимальное кол-во повторов, также контроль дисперсии
            double numForPower = Math.Pow(maxCountForMember, 1 / membersCount); //основание степени
            List<double> powers = new List<double>();


            for (int i = 0; i < membersCount; i++)
                powers.Add(Math.Pow(numForPower, i));

            ShowResult(powers);

            Console.Read();
        }

        public static void ShowResult(List<double> values)
        {
            for (int i = 1; i < values.Count + 1; i++)
                Console.WriteLine($"{i}: {Math.Round(values[i - 1])}");

            double countSum = values.Sum();

            double lastItemInPercent = values.Last() / values.Sum() * 100;

            Console.WriteLine();
            Console.WriteLine("Last item in percent: " + lastItemInPercent);
            Console.WriteLine();

            Console.WriteLine("Avverage: " + GetAvverage(values));
            Console.WriteLine("Disperion: " + GetDisperion(values));
            Console.WriteLine("Standard deviation: " + Math.Sqrt(GetDisperion(values)));

            Console.WriteLine();


            Console.WriteLine("queue size: " + countSum);

            double percent80 = values.Count * 0.80;
            var last20percentValues = values.Skip((int)Math.Round(percent80)).ToArray();
            double last20percentSum = last20percentValues.Sum();
            double last20percentSumInPercent = last20percentSum / values.Sum() * 100;
            Console.WriteLine($"Last 20 percent sum: {last20percentSum} ({last20percentSumInPercent} %)");
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
