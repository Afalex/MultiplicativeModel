using System;

namespace MultiplicativeModel
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 100;
            double z = 100;

            double n = Math.Pow(x, 1 / z);

            for (int i = 0; i < z; i++)
            {
                Console.WriteLine(Math.Pow(n, i));
            }
            Console.Read();
        }
    }
}
