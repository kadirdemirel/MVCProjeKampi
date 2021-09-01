using DataAccessLayer.Concrete;
using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<Category> BlogList()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categories.Add(new Category()
            {

                CategoryName = "Seyehat",
                CategoryCount = 4
            });
            categories.Add(new Category()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            categories.Add(new Category()
            {

                CategoryName = "Spor",
                CategoryCount = 1
            });
            return categories;
        }
        public ActionResult GetData()
        {
            Context context = new Context();
            var query = context.Headings.Include("Category")
                 .GroupBy(p => p.Category.CategoryName)
                 .Select(g => new { name = g.Key, count = g.Sum(w => w.Category.Headings.Count()) }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}