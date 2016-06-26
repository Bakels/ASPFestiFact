using FestiFact.Domain.DAL;
using FestiFact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestiFact.WebUI.Areas.Manager.Models {
    public class OverviewModel {

        List<Organisation> pendingOrganisations = new List<Organisation>();
        List<Organisation> acceptedOrganisations = new List<Organisation>();

        public OverviewModel(EFDbContext context) {

            pendingOrganisations = context.Users.OfType<Organisation>().Where(o => o.Acces == "Wachtend").ToList();
            acceptedOrganisations = context.Users.OfType<Organisation>().Where(o => o.Acces != "Wachtend").ToList();
        }

        public List<Organisation> getPendingOrganisations() {
            return pendingOrganisations;
        }

        public List<Organisation> getAcceptedOrganisations() {
            return acceptedOrganisations;
        }


    }
}