using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class DashboardController : Controller
    {
        private DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult chartjs()
        {
            
            return PartialView();
        }
      public PartialViewResult chartjssendmessage()
        {
            var value = db.TblSkill.ToList();
            return PartialView(value);
        }
        public PartialViewResult chartjsskiil()
        {
            var value = db.GetSendMessageCountLastTop7().ToList();
            return PartialView(value);
        }
        public PartialViewResult chartjscategory()
        {
            var value = db.Getprojectcountcategory().ToList();
            return PartialView(value);
        }
      
        public PartialViewResult statictic()
        {
            ViewBag.CategoryCount = db.TblCategory.Count();
            ViewBag.ProjeCount = db.TblProject.Count();
            ViewBag.SkillCount = db.TblSkill.Count();
            ViewBag.SocialCount = db.TblSocialMedia.Count();
            return PartialView();
        }
        public PartialViewResult messagecountchart()
        {
            return PartialView();
        }
    }
}