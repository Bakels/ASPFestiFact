using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public class Picture {
        public int ID { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Festival> Festivals { get; set; }
    }
}