using Microsoft.AspNetCore.Mvc;

namespace kamo_learnhub.Controllers
{
    public class authController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
