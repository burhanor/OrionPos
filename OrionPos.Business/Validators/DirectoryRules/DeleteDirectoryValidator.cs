using FluentValidation;
using OrionPos.Dto.DirectoryDto;
using OrionPos.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Business.Validators.DirectoryRules
{
    internal class DeleteDirectoryValidator:AbstractValidator<DeleteDirectoryDto>
    {
        public DeleteDirectoryValidator()
        {
        }
    }
}
