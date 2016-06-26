using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FestiFact.Domain.Entities;

namespace FestiFact.Domain.DAL {
    public class EFDbContext : DbContext, IDisposable {
        public EFDbContext() : base("name=EFDbContext") {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<FestivalDate> FestivalDates { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Actor> Actors { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}