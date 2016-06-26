using FestiFact.WebUI.Areas.Manager.Models;
using FestiFact.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestiFact.Domain.Entities;

namespace FestiFact.WebUI.Areas.Manager {
    public class ManagerController : Controller {

        private EFDbContext context = new EFDbContext();
        // GET: Manager

        [HttpGet]
        public ActionResult Overview() {
            OverviewModel model = new OverviewModel(context);

            return View(model);
        }

        public ActionResult AcceptOrDeclineOrganisation(int id, bool b) {

            foreach (var o in context.Users.OfType<Organisation>().ToList()) {

                if (o.ID == id) {

                    if (b) {
                        o.Acces = "Toegang";
                        AddOrUpdateOrganisation(o);
                    } else {
                        context.Users.Remove(o);
                    }

                    context.SaveChanges();
                    return RedirectToAction("Overview");
                }
            }

            return RedirectToAction("Overview");
        }

        [HttpGet]
        public ActionResult AddOrUpdateOrganisation(int id) {

            foreach (var o in context.Users.OfType<Organisation>().ToList()) {

                if (o.ID.Equals(id))
                    return View(o);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddOrUpdateOrganisation(Organisation organisation) {

            if (context.Users.Any(o => o.ID == organisation.ID)) {
                context.Users.Attach(organisation);
                context.Entry(organisation).State = EntityState.Modified;
            } else {
                context.Users.Add(organisation);
            }

            context.SaveChanges();

            return RedirectToAction("Overview");
        }


    }
}

