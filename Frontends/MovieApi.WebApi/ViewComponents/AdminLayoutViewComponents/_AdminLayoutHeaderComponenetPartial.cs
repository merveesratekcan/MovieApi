using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutHeaderComponenetPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
