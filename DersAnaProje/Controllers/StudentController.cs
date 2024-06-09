using DersAnaProje.Models;
using DersAnaProje.Models.Relationships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace DersAnaProje.Controllers
{
    public class StudentController : Controller
    {
        private readonly OkulDBContext ctx;

        public StudentController(OkulDBContext context)
        {
            ctx = context;
        }

        public IActionResult Index()
        {
            var lst = ctx.Ogrenciler.ToList();
            return View(lst);
        }


        [HttpGet] //Bunu default olarak yazmaya gerek yok
        public IActionResult AddStudent()
        {

            return View();
        }

        //Veritabanına inse işlemi yapıyoruz bu gibi işlemler post ile yapılır.
        [HttpPost] //Bunu yazmak zorunlu postlar.
        public IActionResult AddStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditStudent(int id)
        {
            var ogr = ctx.Ogrenciler.Find(id);
            return View(ogr);
        }

        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                ctx.Entry(ogr).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int id)
        {
            var ogr = ctx.Ogrenciler.Find(id);
            if (ogr != null)
            {
                ctx.Ogrenciler.Remove(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        // Öğrencinin aldığı dersleri göster
        public IActionResult OgrenciDersleri(int id)
        {
            var ogrenci = ctx.Ogrenciler.Include(o => o.OgrenciDersler!).ThenInclude(od => od.Ders).FirstOrDefault(o => o.Ogrenciid == id);
            return View(ogrenci);
        }

        // Öğrenciye ders ekle
        [HttpGet]
        public IActionResult AddDersForOgrenci(int studentId)
        {
            var dersler = ctx.Dersler.ToList();
            var ogrenciDersler = ctx.OgrenciDersler.Where(od => od.Ogrenciid == studentId).Select(od => od.Dersid).ToList();
            var AktifDersler = dersler.Where(d => !ogrenciDersler.Contains(d.Dersid)).ToList();

            ViewBag.StudentId = studentId;
            return View(AktifDersler);
        }


        [HttpPost]
        public IActionResult AddDersForOgrenci(int studentId, List<int> dersIds)
        {
            var mevcutDersId = ctx.OgrenciDersler.Where(od => od.Ogrenciid == studentId).Select(od => od.Dersid).ToList();
            var yeniDersId = dersIds.Except(mevcutDersId).ToList();

            foreach (var dersId in yeniDersId)
            {
                var ogrenciDers = new OgrenciDers
                {
                    Ogrenciid = studentId,
                    Dersid = dersId
                };
                ctx.OgrenciDersler.Add(ogrenciDers);
            }
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
