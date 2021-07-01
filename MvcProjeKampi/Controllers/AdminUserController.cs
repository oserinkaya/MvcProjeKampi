using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: AdminUser
        AdminManager adm = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var adminusers = adm.GetList();
            return View(adminusers);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            AdminValidator adminvalidator = new AdminValidator();
            ValidationResult results = adminvalidator.Validate(p);

            if (results.IsValid)
            {
                p.AdminUserName = FormsAuthentication.HashPasswordForStoringInConfigFile(p.AdminUserName, "MD5");
                p.AdminPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(p.AdminPassword, "MD5");
                adm.AdminAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult DeleteAdmin(int id)
        {
            var AdminValue = adm.GetByID(id);
            switch (AdminValue.AdminStatus)
            {
                case true:
                    AdminValue.AdminStatus = false;
                    break;
                case false:
                    AdminValue.AdminStatus = true;
                    break;
            }
            adm.AdminDelete(AdminValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adm.GetByID(id);

            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            p.AdminUserName = FormsAuthentication.HashPasswordForStoringInConfigFile(p.AdminUserName, "MD5");

            adm.AdminUpdate(p);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdminPassword(int id)
        {
            var adminvalue = adm.GetByID(id);

            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdminPassword(Admin p)
        {
            p.AdminPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(p.AdminPassword, "MD5");

            adm.AdminUpdate(p);

            return RedirectToAction("Index");
        }
    }
}