using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context cntxt = new Context();

        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var q1 = cntxt.Categories.Count();
            ViewBag.s1 = q1;

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var q2 = cntxt.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.s2 = q2;

            //Yazar adında 'a' harfi geçen yazar sayısı
            var q3 = cntxt.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.s3 = q3;

            //En fazla başlığa sahip kategori adı
            var q4 = cntxt.Categories.Where(u => u.CategoryID == cntxt.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.s4 = q4;

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var q5 = cntxt.Categories.Count(x => x.CategoryStatus == true) - cntxt.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.s5 = q5;

            return View();
        }
    }
}