using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminLoginManager alm = new AdminLoginManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //Context c = new Context();
            //var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            var adminuser = FormsAuthentication.HashPasswordForStoringInConfigFile(p.AdminUserName, "MD5");
            var adminpass = FormsAuthentication.HashPasswordForStoringInConfigFile(p.AdminPassword, "MD5");

            var adminuserinfo = alm.GetAdmin(adminuser, adminpass);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //return View();
        }
    }
}