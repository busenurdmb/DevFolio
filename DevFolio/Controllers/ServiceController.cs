﻿using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class ServiceController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult ServiceList()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.TblService.Find(id);
            db.TblService.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ServiceList");


        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {

            var value = db.TblService.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var value = db.TblService.Find(p.ServiceID);
            value.ServiceTitle = p.ServiceTitle;
            value.Description= p.Description;
            value.ServiceImageUrl= p.ServiceImageUrl;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}