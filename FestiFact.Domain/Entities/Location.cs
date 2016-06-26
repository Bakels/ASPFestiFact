using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public class Location {

        public Location() {
            this.Festivals = new HashSet<Festival>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public virtual ICollection<Festival> Festivals { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}