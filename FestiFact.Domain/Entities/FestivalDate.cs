using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public class FestivalDate {
        public FestivalDate() {
            this.Festivals = new HashSet<Festival>();
        }
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public virtual ICollection<Festival> Festivals { get; set; }
    }
}