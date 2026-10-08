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
    [Authorize(Roles = "A,B,C")]
    public class ChartsController : Controller
    {
        HeadingManager hdm = new HeadingManager(new EfHeadingDal());

        // Kategori başına düşen başlık sayısını pasta grafiği (Pie Chart) için hazırlar
        public ActionResult PieChart()
        {
            var headings = hdm.HeadingList();

            var chartData = headings
                .GroupBy(x => x.Category.CategoryName)
                .ToDictionary(
                    x => x.Key,   // Kategori Adı
                    x => x.Count() // Başlık Sayısı
                );

            ViewBag.ChartData = chartData;
            return View();
        }

        // Yazar başına düşen başlık sayısını sütun grafiği (Column Chart) için hazırlar
        public ActionResult ColumnChart()
        {
            var headings = hdm.HeadingList();

            var chartData = headings
                .GroupBy(x => x.Writer.WriterName)
                .ToDictionary(
                    x => x.Key,   // Yazar Adı
                    x => x.Count() // Başlık Sayısı
                );

            ViewBag.ChartData = chartData;

            return View();
        }
    }
}