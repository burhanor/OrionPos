using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrionPos.Business.Extensions;
using OrionPos.Business.Services.Abstractions;
using OrionPos.Core.PaginationObjects;
using OrionPos.Core.ResponseObjects;
using OrionPos.DataAccess.UnitOfWork;
using OrionPos.Dto.DirectoryDto;
using OrionPos.Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Business.Services.Concretes
{
    public class DirectoryService: IDirectoryService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUow uow;
        private readonly IMapper mapper;
        private readonly IValidator<CreateDirectoryDto> createValidator;
        private readonly IValidator<UpdateDirectoryDto> updateValidator;
        private readonly IValidator<DeleteDirectoryDto> deleteValidator;
        private readonly ClaimsPrincipal User;


        public DirectoryService(IHttpContextAccessor httpContextAccessor , IUow uow,IMapper mapper,IValidator<CreateDirectoryDto> createValidator, IValidator<UpdateDirectoryDto> updateValidator, IValidator<DeleteDirectoryDto> deleteValidator)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.uow = uow;
            this.mapper = mapper;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
            this.deleteValidator = deleteValidator;
            if (httpContextAccessor.HttpContext is not null)
                User = httpContextAccessor.HttpContext.User;
            else
                User = new();

        }
        public async Task<Response<DirectoryItemDto>> AddAsync(CreateDirectoryDto dto)
        {
            Response<DirectoryItemDto> response = new("Hata",ResponseType.Failed);
            ValidationResult validationResult =  await createValidator.ValidateAsync(dto);
            if (validationResult.IsValid)
            {
                TelephoneDirectory telephoneDirectory = mapper.Map<TelephoneDirectory>(dto);
                telephoneDirectory.CreatedUserId = User.GetUserId();
                await uow.GetRepository<TelephoneDirectory>().AddAsync(telephoneDirectory);
                if(await uow.SaveAsync()>0)
                {
                    response.ResponseType=ResponseType.Success;
                    StringBuilder message = new StringBuilder();
                    message.AppendFormat("Kayıt Eklendi <br>");
                    message.AppendFormat("Ad : {0}<br>", telephoneDirectory.FirstName);
                    message.AppendFormat("Soyad : {0}<br>", telephoneDirectory.LastName);
                    message.AppendFormat("Telefon Numarası : {0}<br>", telephoneDirectory.TelephoneNumber);
                    message.AppendFormat("Eklenme Tarihi : {0}<br>", telephoneDirectory.CreatedDateTime);
                    response.Message = message.ToString();
                    response.Data = mapper.Map<DirectoryItemDto>(telephoneDirectory);
                }
                else
                {
                    response.Message = $"{dto.TelephoneNumber} nolu telefon kaydedilirken beklenmeyen bir hata ile karşılaşıldı";
                }
            }
            else
            {
                response.ResponseType = ResponseType.ValidationError;
                response.ValidationErrors = validationResult.Errors.Select(m => new AppValidationError
                {
                    ErrorMessage = m.ErrorMessage,
                    PropertyName = m.PropertyName
                }).ToList();
            }


            return response;

        }

        public async Task<Response<DirectoryItemDto>> UpdateAsync(UpdateDirectoryDto dto)
        {
            Response<DirectoryItemDto> response = new("Hata", ResponseType.Failed);
            ValidationResult validationResult = await updateValidator.ValidateAsync(dto);
            if (validationResult.IsValid)
            {

              
                TelephoneDirectory telephoneDirectory = await uow.GetRepository<TelephoneDirectory>().GetAsync(m => m.Id == dto.Id);
                StringBuilder message = new StringBuilder();
                message.AppendFormat("Kayıt Güncellendi <br>");
                message.AppendFormat("Ad : {0} => <b>{1}</b><br>", telephoneDirectory.LastName, dto.FirstName);
                message.AppendFormat("Soyad : {0} => <b>{1}</b><br>", telephoneDirectory.FirstName, dto.LastName);
                message.AppendFormat("Telefon Numarası : {0} => <b>{1}</b><br>", telephoneDirectory.TelephoneNumber, dto.TelephoneNumber);
                telephoneDirectory.TelephoneNumber=dto.TelephoneNumber;
                telephoneDirectory.FirstName = dto.FirstName;
                telephoneDirectory.LastName = dto.LastName;
                uow.GetRepository<TelephoneDirectory>().Update(telephoneDirectory);
                if (await uow.SaveAsync() > 0)
                {
                    response.ResponseType = ResponseType.Success;

                    response.Message = message.ToString();
                    response.Data = mapper.Map<DirectoryItemDto>(telephoneDirectory);
                }
                else
                {
                    response.Message = $"Id={dto.Id} olan kayıt güncellenirken beklenmeyen bir hata ile karşılaşıldı";
                }
            }
            else
            {
                response.ResponseType = ResponseType.ValidationError;
                response.ValidationErrors = validationResult.Errors.Select(m => new AppValidationError
                {
                    ErrorMessage = m.ErrorMessage,
                    PropertyName = m.PropertyName
                }).ToList();
            }


            return response;

        }
        public async Task<Response<DirectoryItemDto>> DeleteAsync(DeleteDirectoryDto dto)
        {
            Response<DirectoryItemDto> response = new("Hata", ResponseType.Failed);
            ValidationResult validationResult = await deleteValidator.ValidateAsync(dto);
            if (validationResult.IsValid)
            {
                TelephoneDirectory telephoneDirectory = await uow.GetRepository<TelephoneDirectory>().GetAsync(m => m.Id == dto.Id);
                telephoneDirectory.IsDeleted = true; // Soft Delete
                uow.GetRepository<TelephoneDirectory>().Update(telephoneDirectory);
                if (await uow.SaveAsync() > 0)
                {
                    response.ResponseType = ResponseType.Success;
                    response.Message = $"Id={dto.Id} olan kayıt silindi";
                }
                else
                {
                    response.Message = $"Id={dto.Id} olan kayıt silinirken beklenmeyen bir hata ile karşılaşıldı";
                }
            }
            else
            {
                response.ResponseType = ResponseType.ValidationError;
                response.ValidationErrors = validationResult.Errors.Select(m => new AppValidationError
                {
                    ErrorMessage = m.ErrorMessage,
                    PropertyName = m.PropertyName
                }).ToList();
            }


            return response;

        }


        // Soft Delete
        public async Task<Response<List<int>>> SoftDeleteAsync(List<int> Ids)
        {
            Response<List<int>> response = new("Hata", ResponseType.Failed);
           int effectedRow = await uow.GetRepository<TelephoneDirectory>().Find(m => Ids.Contains(m.Id)).ExecuteUpdateAsync(b => b.SetProperty(x => x.IsDeleted, true));
            if (effectedRow>0)
            {
                response.ResponseType = ResponseType.Success;
                response.Message = $"Seçilen {Ids.Count} adet kayıt silindi";
                response.Data = Ids;
            }
            return response;
        }
    

        public async Task<IList<DirectoryItemDto>> SearchAsync(Pagination pagination) {
            ICollection<TelephoneDirectory> directories = null;
            IList<DirectoryItemDto> results=null;
            if (string.IsNullOrEmpty(pagination.SearchKey))
            {
               directories = await uow.GetRepository<TelephoneDirectory>().GetAllByPaginationAsync(currentPage: pagination.CurrentPage, pageSize: pagination.PageSize);
                
            }
            else
            {
                directories = await uow.GetRepository<TelephoneDirectory>().GetAllByPaginationAsync(
                    predicate:m=>m.FirstName.Contains(pagination.SearchKey) || m.LastName.Contains(pagination.SearchKey) || m.TelephoneNumber.Contains(pagination.SearchKey),
                    currentPage: pagination.CurrentPage,
                    pageSize: pagination.PageSize);

            }
            if (directories is null)
                results = new List<DirectoryItemDto>();
            else
                results=mapper.Map<IList<DirectoryItemDto>>(directories);
            return results;

        }

        public async Task<IList<DirectoryItemDto>> GetAllAsync()
        {
            ICollection<TelephoneDirectory> directories = await uow.GetRepository<TelephoneDirectory>().GetAllAsync(m=>!m.IsDeleted); 
            IList<DirectoryItemDto> results = null;
         
            if (directories is null)
                results = new List<DirectoryItemDto>();
            else
                results = mapper.Map<IList<DirectoryItemDto>>(directories);
            return results;

        }

    }
}
