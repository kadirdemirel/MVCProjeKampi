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
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
       
        // GET: Content

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {

            var values = contentManager.GetListSearch(p);
            if(p==null)
            {
                var values2 = contentManager.GetList();
                return View(values2.ToList());
            }
            return View(values.ToList());
            // var values = context.Contents.ToList();

        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.getListById(id);

            return View(contentValues);
        }
    }
}