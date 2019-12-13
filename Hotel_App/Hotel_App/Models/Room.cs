﻿using System.ComponentModel.DataAnnotations;

namespace Hotel_App.Models
{ 
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; } 
        public int Floor { get; set; }
        public string RoomType { get; set; }
        public string Price { get; set; }
    }
}