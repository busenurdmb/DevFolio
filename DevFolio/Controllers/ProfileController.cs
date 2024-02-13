using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class ProfileController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult ProfileList()
        {
            var values = db.TblProfile.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(TblProfile p)
        {
            db.TblProfile.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        public ActionResult DeleteProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            db.TblProfile.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProfileList");


        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {

            var value = db.TblProfile.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var value = db.TblProfile.Find(p.ProfileID);
            value.NameSurname = p.NameSurname;
            value.Title = p.Title;
            value.Phone = p.Phone;
            value.Email = p.Email;
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }

    }
}