using System;
using System.Collections.Generic;

namespace FilterSortPagingApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public List<Guest> Guests { get; set; }

        public Room()
        {
            Guests = new List<Guest>();
        }
    }
}