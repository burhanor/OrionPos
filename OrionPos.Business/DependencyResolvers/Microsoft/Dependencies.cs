using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OrionPos.Business.Services.Abstractions;
using OrionPos.Business.Services.Concretes;
using OrionPos.Business.Validators.DirectoryRules;
using OrionPos.DataAccess.Repositories;
using OrionPos.DataAccess.UnitOfWork;
using OrionPos.Dto.DirectoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Business.DependencyResolvers.Microsoft
{
    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IDirectoryService, DirectoryService>();


            services.AddTransient<IValidator<CreateDirectoryDto>, CreateDirectoryValidator>();
            services.AddTransient<IValidator<UpdateDirectoryDto>, UpdateDirectoryValidator>();
            services.AddTransient<IValidator<DeleteDirectoryDto>, DeleteDirectoryValidator>();

        }
    }
}
