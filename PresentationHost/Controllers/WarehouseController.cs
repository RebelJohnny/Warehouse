using Microsoft.AspNetCore.Mvc;

namespace PresentationHost.Controllers
{
    public class WarehouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
