using Microsoft.AspNetCore.Mvc;

namespace OrionPos.UI.ViewComponents
{
    public class UpdateDirectoryViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
