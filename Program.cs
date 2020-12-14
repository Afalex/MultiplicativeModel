using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicativeModel
{
    class Program
    {
        static void Main(string[] args)
        {
            double membersCount = 10;
            double maxCountForMember = membersCount * 2.5; //максимальное кол-во повторов, также контроль дисперсии
            double numForPower = Math.Pow(maxCountForMember, 1 / membersCount); //основание степени
            List<double> powers = new List<double>();


            for (int i = 0; i < membersCount; i++)
                powers.Add(Math.Pow(numForPower, i));

            ShowResult(powers);

            Console.Read();
        }

        public static void ShowResult(List<double> values)
        {
            for (int i = 1; i < values.Count+1; i++)
                Console.WriteLine($"{i}: {Math.Round(values[i-1])}");

            Console.WriteLine("Avverage: " + GetAvverage(values));
            Console.WriteLine("Disperion: " + GetDisperion(values));
            Console.WriteLine("Standard deviation: " + Math.Sqrt(GetDisperion(values)));

            Console.WriteLine();

            double countSum = values.Sum();

            Console.WriteLine("queue size: " + countSum);
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
