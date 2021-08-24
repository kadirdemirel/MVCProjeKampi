using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}