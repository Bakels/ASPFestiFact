using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FestiFact.Domain.Entities {
    public class Festival {
        public int ID { get; set; }
        [Required(ErrorMessage = "Voer een naam in")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Voer een beschrijving in")]
        public string Description { get; set; }
        public byte[] Banner { get; set; }
        [Required(ErrorMessage = "Voer een type in")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Voer een gerne in")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Voer een minimum leeftijd in")]
        public int MinAge{ get; set; }
        [Required(ErrorMessage = "Voer een maximum leeftijd in")]
        public int MaxAge { get; set; }
        public int OrganisationID { get; set; }
        public virtual Organisation Organisation { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<FestivalDate> Dates { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}