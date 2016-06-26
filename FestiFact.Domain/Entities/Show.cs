using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public class Show {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public byte[] Image { get; set; }
        public int ExecutorID { get; set; }
        public int RoomID { get; set; }
        public int FestivalID { get; set; }
        public virtual Executor Executor { get; set; }
        public virtual Room Room { get; set; }
        public virtual Festival Festival { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
}
}