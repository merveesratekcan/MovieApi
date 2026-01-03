using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutHeadComponenetPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
