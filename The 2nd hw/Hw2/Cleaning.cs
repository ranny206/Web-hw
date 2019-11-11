using System;
using System.Linq;

namespace Hw2
{
    public class Cleaning
    {
        public void Clean(int room)
        {
            if (room / 1000 == 3)
            {
                foreach (var t in Hotel.Lux.Where(t => t.Number == room))
                {
                    t.IsClean = true;
                    Console.WriteLine("Your room is clean and ready for your visit");
                }
            }
            else
            {
                foreach (var t in Hotel.Rooms.Where(t => t.Number == room))
                {
                    t.IsClean = true;
                    Console.WriteLine("Your room is clean and ready for your visit");
                }
            }
        }

        public void BringBaggage(int room)
        {
            foreach (var t in Hotel.Lux.Where(t => t.Number == room))
            {
                t.Baggage = true;
                Console.WriteLine("Your baggage is waiting for you in the room");
            }
        }

        public void CarryBaggage(int room)
        {
            foreach (var t in Hotel.Lux.Where(t => t.Number == room))
            {
                t.Baggage = false;
                Console.WriteLine("Your baggage is waiting for you in the car");
            }
        }
    }
}