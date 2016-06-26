using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public class Room {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Show> Shows { get; set; }

    }
}