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

        public string ChooseRoomGuest(int room)
        {
            var result = "";
            foreach (var t in Hotel.HotelGuests.Where(t => t.Room == room))
            {
                result = t.Name;
            }
            if (result == "")
            {
                result = "No guests in this room";
            }
            return result;
        }
    }
}