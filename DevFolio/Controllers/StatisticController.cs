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
            return View();
        }
    }
}