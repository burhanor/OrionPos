using Microsoft.AspNetCore.Mvc;
using OrionPos.Business.Services.Abstractions;
using OrionPos.DataAccess.UnitOfWork;
using OrionPos.Dto.DirectoryDto;

namespace OrionPos.UI.ViewComponents
{
    public class DirectoryListViewComponent: ViewComponent
    {
        private readonly IDirectoryService directoryService;

        public DirectoryListViewComponent(IDirectoryService directoryService)
        {
            this.directoryService = directoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IList<DirectoryItemDto> items = await directoryService.GetAllAsync();
            return View(items);
        }
    }
}
