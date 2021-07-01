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

namespace MvcProjeKampi.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sklm = new SkillManager(new EfSkillDal());

        public ActionResult MySkills()
        {
            var mskills = sklm.GetList();
            return View(mskills);
        }

        public ActionResult Index()
        {
            var myskills = sklm.GetList();
            return View(myskills);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            SkillValidator skillvalidator = new SkillValidator();
            ValidationResult results = skillvalidator.Validate(p);

            if (results.IsValid)
            {
                sklm.SkillAdd(p);
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

        public ActionResult DeleteSkill(int id)
        {
            var skillvalue = sklm.GetByID(id);
            sklm.SkillDelete(skillvalue);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillvalue = sklm.GetByID(id);

            return View(skillvalue);
        }

        [HttpPost]
        public ActionResult EditSkill(Skill p)
        {
            sklm.SkillUpdate(p);

            return RedirectToAction("Index");
        }
    }
}