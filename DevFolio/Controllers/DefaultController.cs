using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default,
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.CategoryCount = db.TblCategory.Count();
            ViewBag.ProjeCount = db.TblProject.Count();
            ViewBag.SkillCount = db.TblSkill.Count();
            ViewBag.TestimonialCount = db.TblSkill.Count();
            return PartialView();
        }
        public PartialViewResult PartialPortfolio()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult PartialSendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialSendMessage(TblContact p)
        {
            var value = db.TblContact.Add(p);
            value.SendMessageDate = DateTime.Now;
            value.IsRead = false;
            db.SaveChanges();
            ViewBag.m = "Mesajınız gönderildi.Teşekkür Ederim.";
            ViewBag.c = "show";
            return PartialView();

        }
        public PartialViewResult PartialAddress()
        {
            var values = db.TblAddress.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSocial()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult Partialfooter()
        {
            return PartialView();
        }
        
    }
}