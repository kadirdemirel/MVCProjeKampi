using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files = imageFileManager.GetList();
            return View(files);
        }
        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile imageFile)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/AdminLTE-3.0.4/galery/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                imageFile.ImagePath = "/AdminLTE-3.0.4/galery/" + dosyaadi + uzanti;
                imageFileManager.AddImageFile(imageFile);
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}