using AutoMapper;
using OrionPos.Dto.DirectoryDto;
using OrionPos.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Business.Mappings
{
    public class DirectoryProfile : Profile
    {
        public DirectoryProfile()
        {
            CreateMap<CreateDirectoryDto, DirectoryItemDto>().ReverseMap();
            CreateMap<UpdateDirectoryDto, DirectoryItemDto>().ReverseMap();
            CreateMap<CreateDirectoryDto, TelephoneDirectory>().ReverseMap();
            CreateMap<UpdateDirectoryDto, TelephoneDirectory>().ReverseMap();
            CreateMap<DeleteDirectoryDto, TelephoneDirectory>().ReverseMap();
            CreateMap<DirectoryItemDto, TelephoneDirectory>().ReverseMap();

        }

    }
}
