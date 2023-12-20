using OrionPos.Core.PaginationObjects;
using OrionPos.Core.ResponseObjects;
using OrionPos.Dto.DirectoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Business.Services.Abstractions
{
    public interface IDirectoryService
    {
        Task<Response<DirectoryItemDto>> AddAsync(CreateDirectoryDto dto);
        Task<Response<DirectoryItemDto>> UpdateAsync(UpdateDirectoryDto dto);
        Task<Response<DirectoryItemDto>> DeleteAsync(DeleteDirectoryDto dto);
        Task<IList<DirectoryItemDto>> SearchAsync(Pagination pagination);
        Task<IList<DirectoryItemDto>> GetAllAsync();
        Task<Response<List<int>>> SoftDeleteAsync(List<int> Ids);
    }
}
