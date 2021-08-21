using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager(new EfStudentDal(), new EfTalentDal());
        // GET: Skills
        public ActionResult Index()
        {
            var list = studentManager.GetList();
            return View(list);
        }
      
    }
}