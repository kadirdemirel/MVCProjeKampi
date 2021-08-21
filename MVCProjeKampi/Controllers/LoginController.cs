using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        LoginManager loginManager = new LoginManager();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            try
            {
                loginManager.Login(admin);
                return RedirectToAction("Index", "AdminCategory");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }
            return View();

            //Context context = new Context();
            //var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            //if (adminUserInfo != null)
            //{
            //    FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
            //    Session["AdminUserName"] = adminUserInfo.AdminUserName;//Oturum yönetimi 

            //}
            //else
            //{

            //}




        }


    }
}