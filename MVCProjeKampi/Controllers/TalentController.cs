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
    public class TalentController : Controller
    {
        TalentManager talentManager = new TalentManager(new EfTalentDal());
        StudentManager studentManager = new StudentManager(new EfStudentDal(),new EfTalentDal());
        // GET: Talent
        public ActionResult Index()
        {
            var list = talentManager.GetList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            List<SelectListItem> valueStudent = (from x in studentManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name+" "+x.Surname,
                                                      Value = x.StudentId.ToString()

                                                  }).ToList();

            ViewBag.valueBag = valueStudent;

            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {

            talentManager.AddTalent(talent);
            return RedirectToAction("Index","Student");
        }
        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            List<SelectListItem> valueStudent = (from x in studentManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name + " " + x.Surname,
                                                      Value = x.StudentId.ToString()

                                                  }).ToList();
            ViewBag.valueBag = valueStudent;
            var talentValue = talentManager.GetById(id);
            return View(talentValue);
        }
        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            talentManager.UpdateTalent(talent);
            return RedirectToAction("Index", "Student");
        }
        public ActionResult DeleteTalent(int id)
        {
            var talentValue = talentManager.GetById(id);
            talentManager.DeleteTalent(talentValue);
            return RedirectToAction("Index", "Student");
        }
    }
}