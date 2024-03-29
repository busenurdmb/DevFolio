﻿using DevFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> category = (from x in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            var category = db.TblCategory.Where(m => m.CategoryID == p.TblCategory.CategoryID).FirstOrDefault();
            p.TblCategory = category;
            p.CreatedDate = DateTime.Now;
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProject.Find(id);
            db.TblProject.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var values = db.TblProject.Find(id);
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProject.Find(p.ProjectID);
            values.Title = p.Title;
            values.ProjectCategory = p.TblCategory.CategoryID;
            values.CoverImageUrl = p.CoverImageUrl;
            values.CreatedDate = p.CreatedDate;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}