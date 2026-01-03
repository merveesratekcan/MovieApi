using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

public class MovieController : Controller
{
    [Area("Admin")]
    public IActionResult MovieList()
    {
        return View();
    }
}
