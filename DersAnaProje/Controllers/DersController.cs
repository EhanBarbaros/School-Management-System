using DersAnaProje.Models;
using DersAnaProje.Models.Relationships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DersAnaProje.Controllers
{
    public class DersController : Controller
    {
        private readonly OkulDBContext ctx;

        public DersController(OkulDBContext context)
        {
            ctx = context;
        }

        public IActionResult Index()
        {
            var lst = ctx.Dersler.ToList();
            return View(lst);
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
                ctx.Dersler.Add(ders);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditDers(int id)
        {
            var ders = ctx.Dersler.Find(id);
            return View(ders);
        }

        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            if (ders != null)
            {
                ctx.Entry(ders).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDers(int id)
        {
            var ders = ctx.Dersler.Find(id);
            if (ders != null)
            {
                ctx.Dersler.Remove(ders);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult KayitliOgrenciler(int id)
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
