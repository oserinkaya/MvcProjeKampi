using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        HeadingManager chm = new HeadingManager(new EfHeadingDal());

        public ActionResult Index()
        {
            return View(new CalendarClass());
        }

        public JsonResult GetHeadings(DateTime start, DateTime end)
        {
            var viewmodel = new CalendarClass();
            var events = new List<CalendarClass>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var item in chm.GetList())
            {
                events.Add(new CalendarClass()
                {
                    title = item.HeadingName,
                    start = item.HeadingDate,
                    end = item.HeadingDate.AddDays(-14),
                    allday = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }

            return Json(events.ToArray(),JsonRequestBehavior.AllowGet);
        }
    }
}