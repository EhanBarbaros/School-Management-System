using DersAnaProje.Models;
using DersAnaProje.Models.Relationships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DersAnaProje.Controllers
{
    public class DersController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OkulDBContext())
            {
                var lst = ctx.Dersler.ToList();
                return View(lst);
            }
        }

        [HttpGet]
        public IActionResult AddDers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OkulDBContext())
                {
                    ctx.Dersler.Add(ders);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditDers(int id)
        {
            using (var ctx = new OkulDBContext())
            {
                var ders = ctx.Dersler.Find(id);
                return View(ders);
            }
        }

        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OkulDBContext())
                {
                    ctx.Entry(ders).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDers(int id)
        {
            using (var ctx = new OkulDBContext())
            {
                var ders = ctx.Dersler.Find(id);
                if (ders != null)
                {
                    ctx.Dersler.Remove(ders);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult KayitliOgrenciler(int id)
        {
            using (var ctx = new OkulDBContext())
            {
                var ders = ctx.Dersler.Include(d => d.OgrenciDersler!).ThenInclude(od => od.Ogrenci!).FirstOrDefault(d => d.Dersid == id);
                if (ders == null)
                {
                    return NotFound();
                }

                if (ders.OgrenciDersler == null)
                {
                    ders.OgrenciDersler = new List<OgrenciDers>();
                }

                return View(ders);
            }
        }
    }
}