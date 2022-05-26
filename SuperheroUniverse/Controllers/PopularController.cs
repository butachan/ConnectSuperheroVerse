using Microsoft.AspNetCore.Mvc;

namespace SuperheroUniverse.Controllers
{
    public class PopularController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
