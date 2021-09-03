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
        public List<TalentChart> TalentList()
        {
            List<TalentChart> talentCharts = new List<TalentChart>();
            using (var context = new Context())
            {
                talentCharts = context.Talents.Select(c => new TalentChart
                {
                    TalentName = c.TalentName,
                    TalentLevel = c.TalentLevel
                }).ToList();
            }

            return talentCharts;
        }

        public ActionResult TalentChart()
        {
            return Json(TalentList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult TalentLineChart()
        {
            return View();
        }
        public List<WriterChart> WriterList()
        {
            List<WriterChart> writerCharts = new List<WriterChart>();
            using (var context = new Context())
            {
                writerCharts = context.Writers.Select(c => new WriterChart
                {
                    WriterName = c.UserName,
                    WriterCount = c.Headings.Count()
                }).ToList();
            }

            return writerCharts;
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult WriterColumnChart()
        {
            return View();
        }
    }
}