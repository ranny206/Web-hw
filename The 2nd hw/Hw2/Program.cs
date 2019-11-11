using System;
using System.Reflection;

namespace Hw2
{
    class Program
    {
        static void HotelFunc()
        {
            ReseptionAdministrator reseptionAdministrator = new ReseptionAdministrator();
            Flag:
                Console.WriteLine("If you want to check in press 1");
                Console.WriteLine("If you want to moved in press 2");
                string answer = Console.ReadLine();
            if (answer != "1" && answer != "2")
            {
                Console.WriteLine("No offer with this code");
                goto Flag;
            }
            switch (answer)
            {
                case "1":
                    Console.WriteLine("Write your name, please");
                    string name = Console.ReadLine();
                    Console.WriteLine("Write wanted room type, please");
                    string roomType = Console.ReadLine();
                    if (roomType != "Single" && roomType != "Double" && roomType != "Lux" && 
                        roomType != "single" && roomType != "double" && roomType != "lux")
                    {
                        Console.WriteLine("No rooms with this room type");
                        goto case "1";
                    }
                    reseptionAdministrator.CheckIn(name, roomType);
                    break;
                case "2":
                    Console.WriteLine("Write your room, please");
                    int room = Convert.ToInt16(Console.ReadLine());
                    reseptionAdministrator.CheckOut(room);
                    break;
            }
        }

        static void Main(string[] args)
        {
            ask:
                Console.WriteLine("If you are hotel guest press F, if you are restaurant guest press R, else press A");
                string ans = Console.ReadLine();
            if (ans != "f" && ans != "F" &&
                ans != "r" && ans != "R" &&
                ans != "a" && ans != "A")
            {
                Console.WriteLine("No offer with this code");
                goto ask;
            }
            else
            {
                HotelFunc();
            }
        }
    }
}