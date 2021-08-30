using BusinessLayer.Concrete;
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
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {



            p = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var contentValues = contentManager.GetListByWriter(writerId);

            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.deger = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == mail).Select(x => x.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerId;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");

        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}