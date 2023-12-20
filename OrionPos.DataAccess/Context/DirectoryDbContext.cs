using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrionPos.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.DataAccess.Context
{
    public class DirectoryDbContext:IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public DirectoryDbContext(DbContextOptions options):base(options)
        {
            Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var assembly = Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        #region Tables
        public DbSet<TelephoneDirectory> TelephoneDirectories { get; set; }
        #endregion


    }
}
