using System;
using System.Collections.Generic;

namespace Web6_2
{
    public partial class Guests
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int RoomId { get; set; }

        public virtual Rooms Room { get; set; }
    }
}
