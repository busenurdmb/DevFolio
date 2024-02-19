using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.TblCategory.Count();
            ViewBag.ProjeCount = db.TblProject.Count();
            ViewBag.SkillCount = db.TblSkill.Count();
            ViewBag.SkillavgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.SkillLastTitle = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.Categorylast = db.GetLastCategoryName().FirstOrDefault();
            ViewBag.CategoryFirst= db.TblCategory.OrderBy(x => x.CategoryID).FirstOrDefault().CategoryName;
            ViewBag.ProjectLast = db.TblProject.OrderByDescending(x => x.ProjectID).FirstOrDefault().Title;
            ViewBag.ProjectFirst = db.TblProject.OrderBy(x => x.ProjectID).FirstOrDefault().Title;
            ViewBag.Admin = db.TblAdmin.OrderBy(x=>x.AdminID).FirstOrDefault().Username;
            ViewBag.SocialCount = db.TblSocialMedia.Count();
            return View();
        }
    }
}