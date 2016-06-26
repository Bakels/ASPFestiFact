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

            Organisation organisation = (Organisation)context.Users.Find(id);

            if (b) {
                organisation.Acces = "Toegang";
                context.Entry(organisation).State = EntityState.Modified;
            } else context.Users.Remove(organisation);


            context.SaveChanges();
            return RedirectToAction("Overview");
        }

        [HttpGet]
        public ActionResult UpdateOrganisation(int id ) {

            if (id != 0) {
                Organisation organisation = (Organisation)context.Users.Find(id);
                return View(organisation);
            } else return View();

        }
       
        [HttpPost]
        public ActionResult UpdateOrganisation(Organisation organisation) {

            context.Entry(organisation).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Overview");
        }

    }
}

