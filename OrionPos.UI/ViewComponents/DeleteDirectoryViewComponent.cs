using Microsoft.AspNetCore.Mvc;
using OrionPos.Dto.DirectoryDto;

namespace OrionPos.UI.ViewComponents
{
    public class DeleteDirectoryViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
