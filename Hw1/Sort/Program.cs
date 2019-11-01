using System;

namespace Sort
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
            int temp;
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}