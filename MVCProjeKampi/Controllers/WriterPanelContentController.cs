using BusinessLayer.Concrete;
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
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            var contentValues = contentManager.GetListByWriter();

            return View(contentValues);
        }
    }
}