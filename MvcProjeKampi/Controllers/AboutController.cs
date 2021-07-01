using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult DeleteAbout(int id)
        {
            var AboutValue = abm.GetByID(id);
            switch (AboutValue.AboutStatus)
            {
                case true:
                    AboutValue.AboutStatus = false;
                    break;
                case false:
                    AboutValue.AboutStatus = true;
                    break;
            }
            abm.AboutDelete(AboutValue);
            return RedirectToAction("Index");
        }
    }
}