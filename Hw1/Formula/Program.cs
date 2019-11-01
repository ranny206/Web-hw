using System;

namespace Formula
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the first element");
            int a = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Write step of progression");
            int d = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Write the number of the last element");
            int last = Convert.ToInt16(Console.ReadLine());
            double S = (last * (2 * a + ((last - 1) * d))) / 2;
            Console.WriteLine(S);

            //double angle cos
            Console.WriteLine("Enter an angle");
            int angle = Convert.ToInt16(Console.ReadLine());
            double doubleAngle = Math.Pow(Math.Cos(angle), 2) - Math.Pow(Math.Sin(angle), 2);
            Console.WriteLine(doubleAngle);
            
            //period of pendulum
            double g = 9.80666;
            Console.WriteLine("Enter a length");
            double l = Convert.ToDouble(Console.ReadLine());
            double T = 2 * Math.PI * Math.Sqrt((l / g));
            Console.WriteLine(T);
            
            //frustum
            Console.WriteLine("Enter the first radius");
            double r1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second radius");
            double r2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter a height");
            double h = Convert.ToDouble(Console.ReadLine());
            double V = (1/3) * h * (Math.Pow(r1, 2) + r1 * r2 + Math.Pow(r2, 2));
            Console.WriteLine(V);
        }
    }
}