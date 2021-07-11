using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }

        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile galleryimagefile)
        {
            if (Request.Files.Count > 0)
            {
                string galleryimagefilename = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string galleryimagefileextension = Path.GetExtension(Request.Files[0].FileName);
                string path = "/ImageGallery/" + galleryimagefilename + galleryimagefileextension;

                Request.Files[0].SaveAs(Server.MapPath(path));
                galleryimagefile.ImagePath = "/ImageGallery/" + galleryimagefilename + galleryimagefileextension;
                ifm.ImageAdd(galleryimagefile);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}