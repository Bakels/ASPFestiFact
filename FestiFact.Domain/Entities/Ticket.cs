using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public class Ticket {
        public int ID { get; set; }
        public double Price { get; set; }
        public int VisitorID { get; set; }
        public int ShowID { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual Show Show { get; set; }
    }
}