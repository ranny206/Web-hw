using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_v_vide_gnomika.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string RoomType { get; set; }

        public virtual List<Guest> Guests { get; set; }

        public Room()
        {
            Guests = new List<Guest>();
        }
    }
}
