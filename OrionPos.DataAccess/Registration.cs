using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrionPos.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.DataAccess
{
    public static class Registration
    {
        public static void AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DirectoryDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
                
            });
            
        }

    }
}
