namespace FestivalApp.Migrations
{
    using FestiFact.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net;
    internal sealed class Configuration : DbMigrationsConfiguration<FestiFact.Domain.DAL.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FestiFact.Domain.DAL.EFDbContext context){

            var Users = new List<User> {
                new Manager {ID = 1, Username = "Rico", Email ="Ricobakels2@hotmail.com", Password ="Bakels", Role ="Manager", Logged = true },
                new Organisation {ID = 2, Username = "Q-Dance", Email ="Q-Dance@hotmail.com", Password ="Q-Dance", Role ="Organisation", Logged = false, Acces = "Wachtend", Name = "Q-Dance", Tel = "0656869786", Comment = "Een q-base comment"},
                new Organisation {ID = 3, Username = "Awakenings", Email ="Awakanings@hotmail.com", Password ="Awakenings", Role ="Organisation", Logged = false, Acces = "Wachtend", Name = "Awakenings",  Tel = "0678694323", Comment = "Een Awakenings comment"}
            };
            Users.ForEach(u => context.Users.AddOrUpdate(u));

            var Actors = new List<Actor> {
                new Actor { ID = 1, Name = "Steven Segael" },
                new Actor { ID = 2, Name = "Tom Cruise" }
            };
            Actors.ForEach(a => context.Actors.AddOrUpdate(a));



            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData("http://zingenmaar.nl/wp-content/uploads/2015/02/dikke-duim-2.jpg");

            var Executors = new List<Executor> {
                new ArtistOrGroup {ID = 1, Description = "Dit is artiest één", HomeCountry = "Nederland", Genre = "Techno", ArtistName = "Boris Brechja", Image = imageBytes, Type = "Muziek" },
                new Movie { ID = 2, Description = "Dit is film één", HomeCountry = "Belgie", Genre = "Actie", MovieName = "Die Hard", Director = "Rico Director", PublishYear = 2016, Actors = Actors }

            };
            Executors.ForEach(e => context.Executors.AddOrUpdate(e));

            context.SaveChanges();
        }
    }
}
