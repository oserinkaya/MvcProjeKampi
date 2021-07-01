using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        Context msgstatus = new Context();

        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult ContactSideMenuPartial()
        {
            //Okunmamış Mesaj Sayısı
            var UnreadMessageCount = msgstatus.Messages.Count(x => x.MessageReadStatus == false && x.ReceiverMail == "admin@gmail.com");
            ViewBag.umc = UnreadMessageCount;

            //Okunmuş Mesaj Sayısı
            var ReadMessageCount = msgstatus.Messages.Count(x => x.MessageReadStatus == true && x.ReceiverMail == "admin@gmail.com");
            ViewBag.rmc = ReadMessageCount;

            //Toplam Mesaj Sayısı
            var TotalMessageCount = msgstatus.Messages.Count(x => x.ReceiverMail == "admin@gmail.com");
            ViewBag.tmc = TotalMessageCount;

            return PartialView();
        }
    }
}