using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestiFact.Domain.DAL;
using FestiFact.Domain.Entities;
using FestiFact.WebUI.Areas.Organisator.Models;
using System.Drawing;
using System.IO;
using System.Data.Entity;

namespace FestiFact.WebUI.Areas.Organisator.Controllers {
    public class OrganisatorController : Controller {
        EFDbContext context = new EFDbContext();
        // GET: Organisator/Organisator

        Organisation currentOrganisation;
        public ActionResult Overview() {
            List<Organisation> organisations = context.Users.OfType<Organisation>().ToList();

            currentOrganisation = (Organisation)context.Users.OfType<Organisation>().ToList().Where(u => u.Logged == true).First();

            if (!(currentOrganisation.Festivals.Any())) {

                return View("FirstFestival");
            }

            return View(currentOrganisation);
        }


        [HttpGet]
        public ActionResult AddFestival(int id = 0) {
            NewFestivalModel model;

            if (id == 0) return View();
            else {
                Festival festival = context.Festivals.Find(id);
                model = new NewFestivalModel {
                    festival = festival,
                    dates = festival.Dates.ToList(),
                    locations = festival.Locations.ToList()
                };

                model.dates.Add(null);
                model.dates.Add(null);
                model.dates.Add(null);

                model.locations.Add(null);
                model.locations.Add(null);
                model.locations.Add(null);

                return View(model);
            }

        }

        [HttpPost]
        public ActionResult AddFestival(NewFestivalModel model) {

            if (ModelState.IsValid) {
                List<Location> modelLocations = model.locations.Where(x => x.City != null).ToList();
                List<Location> dbLocations = new List<Location>();

                foreach (var l in modelLocations) {
                    if (context.Locations.FirstOrDefault(f => f.City.Equals(l.City)) != null) {
                        dbLocations.Add(context.Locations.FirstOrDefault(f => f.City.Equals(l.City)));
                    } else dbLocations.Add(l);
                }

                List<FestivalDate> modelDates = model.dates.Where(x => x.Datum != DateTime.MinValue).ToList();
                List<FestivalDate> dbDates = new List<FestivalDate>();

                foreach (var d in modelDates) {
                    if (context.FestivalDates.FirstOrDefault(f => f.Datum.Equals(d.Datum)) != null) {
                        dbDates.Add(context.FestivalDates.FirstOrDefault(f => f.Datum.Equals(d.Datum)));
                    } else dbDates.Add(d);
                }

                List<Picture> modelPictures = new List<Picture>();
                List<Picture> dbPictures = new List<Picture>();

                foreach (var p in model.pictures) {
                    if (p != null) {
                        BinaryReader b = new BinaryReader(p.InputStream);
                        byte[] pic = b.ReadBytes(p.ContentLength);
                        modelPictures.Add(new Picture { Image = pic });

                    }
                }

                foreach (var p in modelPictures) {
                    if (context.Pictures.FirstOrDefault(f => f.Image.Equals(p.Image)) != null) {
                        dbPictures.Add(context.Pictures.FirstOrDefault(f => f.Image.Equals(p.Image)));
                    } else dbPictures.Add(p);
                }

                List<Organisation> organisations = context.Users.OfType<Organisation>().ToList();
                currentOrganisation = (Organisation)context.Users.OfType<Organisation>().ToList().Where(u => u.Logged == true).First();


                model.festival.OrganisationID = currentOrganisation.ID;
                model.festival.Locations = dbLocations;
                model.festival.Dates = dbDates;
                model.festival.Pictures = dbPictures;

                if (context.Festivals.Any(f => f.ID == model.festival.ID)) {

                    context.Festivals.Attach(model.festival);
                    context.Entry(model.festival).State = EntityState.Modified;
                } else {
                    context.Festivals.Add(model.festival);
                }

                context.SaveChanges();
                return View("Overview", currentOrganisation);
            } else return View();
        }
    }
}