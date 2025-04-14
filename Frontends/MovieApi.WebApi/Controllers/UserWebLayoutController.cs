using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class UserWebLayoutController : Controller
    {
        public IActionResult LayoutUI()
        {
            return View();
        }
    }
}
