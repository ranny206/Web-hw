using System;
using System.Collections.Generic;

namespace Web6_2
{
    public partial class Rooms
    {
        public Rooms()
        {
            Guests = new HashSet<Guests>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string RoomType { get; set; }

        public virtual ICollection<Guests> Guests { get; set; }
    }
}
