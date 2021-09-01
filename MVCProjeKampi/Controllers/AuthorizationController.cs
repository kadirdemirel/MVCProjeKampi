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
    public class AuthorizationController : Controller
    {
        ManagerManager managerManager = new ManagerManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var admin = managerManager.GetList();
            return View(admin);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            managerManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = managerManager.GetById(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            managerManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateIsActivatedTrue(int id)
        {
            var authValue = managerManager.GetById(id);
            authValue.IsActivated = true;
            managerManager.IsActivatedTrue(authValue);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateIsActivatedFalse(int id)
        {
            var authValue = managerManager.GetById(id);
            authValue.IsActivated = false;
            managerManager.IsActivatedFalse(authValue);
            return RedirectToAction("Index");
        }
    }
}