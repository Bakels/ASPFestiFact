using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FestiFact.Domain.Entities;
using System.IO;

namespace FestiFact.WebUI.Areas.Organisator.Models {
    public class NewFestivalModel {

        public List<Location> locations { get; set; }
        public List<FestivalDate> dates { get; set; }
        public List<HttpPostedFileBase> pictures { get; set; }
        public Festival festival { get; set; }

    }

}