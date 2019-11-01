using System;

namespace Generation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array");
            int a = Convert.ToInt16(Console.ReadLine());
            int[] array = new int[a];
            Console.WriteLine("Enter min number");
            int minimum = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter max number");
            int maximum = Convert.ToInt16(Console.ReadLine());
            Random rnd = new Random();

            for (int i = 0; i < a; i++)
            {
                array[i] = rnd.Next(minimum, maximum);
            }
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}