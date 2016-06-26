using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FestiFact.Domain.Entities {
    public class Festival {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Banner { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public int MinAge{ get; set; }
        public int MaxAge { get; set; }
        public int OrganisationID { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<FestivalDate> Dates { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}