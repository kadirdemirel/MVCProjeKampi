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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: Home
        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id = 0)
        {
            var contentList = contentManager.getListById(id);
            return PartialView(contentList);
        }
        public ActionResult HomePage()
        {

            var deger = contentManager.GetList();
            ViewBag.value = deger.Count();

            var deger2 = headingManager.GetList();
            ViewBag.value2 = deger2.Count();

            var deger3 = writerManager.GetList();
            ViewBag.value3 = deger3.Count();

            var deger4 = categoryManager.GetList();
            ViewBag.value4 = deger4.Count();
            return View();
        }
    }
}