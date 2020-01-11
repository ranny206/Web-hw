using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilterSortPagingApp.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Room> rooms, int? room, string name)
        {
            rooms.Insert(0, new Room { Number = "All", Id = 0 });
            Rooms = new SelectList(rooms, "Id", "Number", room);
            SelectedRoom = room;
            SelectedName = name;
        }
        public SelectList Rooms { get; private set; } // список компаний
        public int? SelectedRoom { get; private set; }   // выбранная компания
        public string SelectedName { get; private set; }    // введенное имя
    }
}