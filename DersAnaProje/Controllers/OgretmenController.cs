using Microsoft.AspNetCore.Mvc;

namespace DersAnaProje.Controllers
{
    public class OgretmenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult OgretmenListe()
        {
            return View();
        }
    }
}
