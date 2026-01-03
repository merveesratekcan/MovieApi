using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutSidebarComponenetPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
