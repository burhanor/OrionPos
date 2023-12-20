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
    internal class UpdateDirectoryValidator:AbstractValidator<UpdateDirectoryDto>
    {
        public UpdateDirectoryValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz").WithName("Ad");
            RuleFor(m => m.LastName)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz").WithName("Soyad");
            RuleFor(m=>m.TelephoneNumber)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz").WithName("Telefon Numarası");
        }
    }
}
