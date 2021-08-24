﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.value = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string sessionWriterMail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == sessionWriterMail).Select(x => x.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerId;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.valueBag = valueCategory;
            var HeadingValue = headingManager.GetById(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }


    }
}