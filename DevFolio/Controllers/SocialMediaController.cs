using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        
        public ActionResult SocialMediaList()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }
    }
}