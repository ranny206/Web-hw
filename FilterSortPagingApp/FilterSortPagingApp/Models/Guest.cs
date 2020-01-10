using System;

namespace FilterSortPagingApp.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        
        public int RoomId { get; set; }
        public Room Room { get; set; }
        
        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime
        {
            get
            {
                return DateTime.Now - CreationDate;
            }
        }
    }
}