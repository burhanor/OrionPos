using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrionPos.Business.DependencyResolvers.Microsoft;
using OrionPos.DataAccess;
using OrionPos.DataAccess.Context;
using OrionPos.DataAccess.Repositories;
using OrionPos.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Business
{
    public static class Registration
    {
        public static void AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccess(configuration);
            services.AddDependencies();
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
         
        }
    }
}
