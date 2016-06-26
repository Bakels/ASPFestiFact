using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestiFact.Domain.DAL;
using FestiFact.Domain.Entities;

namespace FestiFact.WebUI.Areas.Organisator.Controllers
{
    public class ImageController : Controller
    {
        EFDbContext context = new EFDbContext();
        
        // GET: Organisator/Image
        public ActionResult Show(int festid, int picid) {
            var imageData = context.Festivals.Find(festid).Pictures.Where(p => p.ID == picid).FirstOrDefault().Image;
    

        return File(imageData, "image/jpg");
        }
    }
}