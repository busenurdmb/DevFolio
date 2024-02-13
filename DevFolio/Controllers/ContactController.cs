using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            var value = db.TblContact.Add(p);
            db.SaveChanges();

            return RedirectToAction("MessageList");
        }

        public ActionResult MessageList()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }
    }
}
//camelCase->sade baş harf küçük
//pascalCase->başharf büüyk
//Snakecase->hepsi küçük
//deişkenlerde-metotler-filek-property-ınterface-