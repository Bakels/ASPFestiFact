using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public class Visitor {

        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}