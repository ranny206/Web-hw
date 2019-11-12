using System;
using System.Collections.Generic;
using System.Linq;

namespace Hw2
{
    public class SeniorAdministrator: ReseptionAdministrator
    {
        public List<string> ChooseAllGuests()
        {
            if(Hotel.HotelGuests.Count != 0)
            {
                return Hotel.HotelGuests.Select(t => t.Name).ToList();
            }
            else
            {
                List<string> list = new List<string>(1);
                list.Insert(0,"No guests");
                return list;
            }
        }

        public List<string> ChooseFloorGuests(int floor)
        {
            List<string> list = new List<string>();
            var index = 0;
            for (int i = 0; i < Hotel.HotelGuests.Count; i++)
            {
                if (Hotel.HotelGuests[i].Room / 1000 == floor)
                {
                    list.Insert(index, Hotel.HotelGuests[i].Name);
                    index++;
                }
            }
            if (list.Count == 0)
            {
                list.Insert(0, "No guests on this floor");
            }

            return list;
        }

        public List<string> ChooseRoomGuest(int room)
        {
            var list = new List<string>();
            var index = 0;
            for (int i = 0; i < Hotel.HotelGuests.Count; i++)
            {
                if (Hotel.HotelGuests[i].Room == room)
                {
                    list.Insert(index, Hotel.HotelGuests[i].Name);
                    index++;
                }
            }
            if (list.Count == 0)
            {
                list.Insert(0, "No guests on this floor");
            }

            return list;
        }
    }
}