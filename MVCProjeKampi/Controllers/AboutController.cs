using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult UpdateValueAbout(int id)
        {
            aboutManager.UpdateValueAbout(id);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateIsActivatedTrue(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            aboutValue.IsActivated = true;
            aboutManager.IsActivatedTrue(aboutValue);
            return RedirectToAction("index");
        }
        public ActionResult UpdateIsActivatedFalse(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            aboutValue.IsActivated = false;
            aboutManager.IsActivatedFalse(aboutValue);
            return RedirectToAction("index");
        }
    }
}