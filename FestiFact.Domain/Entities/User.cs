using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestiFact.Domain.Entities {
    public class User {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Logged { get; set; }
    }

    [Table("Organisaton")]
    public class Organisation : User {
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Tel { get; set; }
        public string Acces { get; set; }
        public virtual ICollection<Festival> Festivals { get; set; }
    }

    [Table("Manager")]
    public class Manager : User {

    }
}