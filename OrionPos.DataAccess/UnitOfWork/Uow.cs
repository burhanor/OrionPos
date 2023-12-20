using OrionPos.DataAccess.Context;
using OrionPos.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.DataAccess.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly DirectoryDbContext dbContext;

        public Uow(DirectoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Save() => dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
        IRepository<T> IUow.GetRepository<T>() => new Repository<T>(dbContext);
    }
}
