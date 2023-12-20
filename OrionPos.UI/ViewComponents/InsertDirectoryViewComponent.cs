using Microsoft.AspNetCore.Mvc;

namespace OrionPos.UI.ViewComponents
{
    public class InsertDirectoryViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        } 
    }
}
