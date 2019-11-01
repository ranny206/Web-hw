using System;

namespace Operations
{
    class Program
    {
        static void Counter()
        {
            Console.WriteLine("Choose operation +, -, *, /");
            string operation = Console.ReadLine();
            while (operation != "+" && operation != "-" && operation != "*" && operation != "/"){
                Console.WriteLine("Are you stupid!? Wrong data! Choose operation +, -, *, /");
                operation = Console.ReadLine();
            }
            Console.WriteLine("Enter first number");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Are you stupid!? Wrong data! Enter first number");
            }
            Console.WriteLine("Enter second number");
            int b;
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Are you stupid!? Wrong data! Enter first number");
            }

            switch (operation)
            {
                case "+":
                    Console.WriteLine(a + b);
                    break;
                case "-":
                    Console.WriteLine(a - b);
                    break;
                case "*":
                    Console.WriteLine(a * b);
                    break;
                default:
                    if (b == 0)
                    {
                        Console.WriteLine("Are you stupid!? You can`t divide by zero!");
                    }
                    else
                    {
                        Console.WriteLine(Convert.ToDouble(a) / b);
                    }
                    break;
            }
            Console.WriteLine("If you wanna stop counting write STOP else write something");
        }
        static void Main(string[] args)
        {
            Counter();
            while (Console.ReadLine() != "STOP")
            {
                Counter();
            }
        }
    }
}