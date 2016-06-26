using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FestiFact.Domain.Entities {
    public abstract class Executor {
        public int ID { get; set; }
        public string Description { get; set; }
        public string HomeCountry { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }

    [Table("Movie")]
    public class Movie : Executor {
        public string MovieName { get; set; }
        public string Director { get; set; }
        public int PublishYear { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }

    [Table("ArtistOrGroup")]
    public class ArtistOrGroup : Executor {
        public string ArtistName { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }
    }
}