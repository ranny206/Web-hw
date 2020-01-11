using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_v_vide_gnomika.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
