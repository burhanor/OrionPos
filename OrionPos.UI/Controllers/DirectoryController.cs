using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrionPos.Business.Services.Abstractions;
using OrionPos.Core.ResponseObjects;
using OrionPos.Dto.DirectoryDto;
using OrionPos.Dto.Interfaces;
using OrionPos.UI.Helpers.Extensions;

namespace OrionPos.UI.Controllers
{

    [Authorize]
    public class DirectoryController : Controller
    {
        private readonly IDirectoryService directoryService;
        private readonly INotyfService notyfService;

        public DirectoryController(IDirectoryService directoryService,INotyfService notyfService)
        {
            this.directoryService = directoryService;
            this.notyfService = notyfService;
        }

        [HttpGet]
        [Route("")]
        [Route("telefon-rehberi")]
        public IActionResult TelephoneDirectory()
        {
            return View();
        }


        [HttpGet]
        [Route("kayitlari-getir")]
        public async Task<IActionResult> GetRecords()
        {
            IList<DirectoryItemDto> response = await directoryService.GetAllAsync();
            return Json(response);
        }



        #region Add

        [HttpPost]
        [Route("kayit-ekle")]
        public async Task<IActionResult> CreatePhoneRecord(CreateDirectoryDto dto)
        {
            IResponse<DirectoryItemDto> response = await directoryService.AddAsync(dto);
            return this.ReturnJson(response,notyfService);
        }

        #endregion

        #region Update
        
        [HttpPost]
        [Route("kayit-guncelle")]
        public async Task<IActionResult> UpdatePhoneRecord(UpdateDirectoryDto dto)
        {
            IResponse<DirectoryItemDto> response = await directoryService.UpdateAsync(dto);
            return this.ReturnJson(response, notyfService);
        }
        #endregion

        #region Delete



        [HttpPost]
        [Route("kayit-sil")]
        public async Task<IActionResult> DeletePhoneRecord(List<int> Ids)
        {
            IResponse<List<int>> response = await directoryService.SoftDeleteAsync(Ids);
            return this.ReturnJson(response, notyfService);
        }

        #endregion

    }
}
