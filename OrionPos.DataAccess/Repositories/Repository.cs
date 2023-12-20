using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrionPos.Core.Entities;
using OrionPos.DataAccess.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OrionPos.DataAccess.Repositories
{
    public class Repository<T> :IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DirectoryDbContext dbContext;

        public Repository(DirectoryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task AddAsync(T entity) => await Table.AddAsync(entity);

        public void Delete(T entity) => Table.Remove(entity);

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate is not null)
                return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            IQueryable<T> query = Table;
            if (!enableTracking)
                query = query.AsNoTracking();
            if (predicate is not null)
                query = query.Where(predicate);
            return query;
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? order = null, bool enableTracking = false)
        {
            IQueryable<T> query = Table;
            if (!enableTracking)
                query = query.AsNoTracking();
            if (predicate is not null)
                query = query.Where(predicate);
            if (include is not null)
                query = include(query);
            if (order is not null)
                query = order(query);

            return await query.ToListAsync();

        }

        public async Task<ICollection<T>> GetAllByPaginationAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? order = null, bool enableTracking = false,int currentPage=1,int pageSize=10)
        {
            IQueryable<T> query = Table;
            if (!enableTracking)
                query = query.AsNoTracking();
            if (predicate is not null)
                query = query.Where(predicate);
            if (include is not null)
                query = include(query);
            if (order is not null)
                query = order(query);

            return await query.Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> query = Table;

            if (!enableTracking)
                query = query.AsNoTracking();
            if (predicate is not null)
                return await query.FirstOrDefaultAsync(predicate) ?? new T();
            return await query.FirstOrDefaultAsync() ?? new T();
        }

        public void Update(T unchanged, T updateEntity) => Table.Entry(unchanged).CurrentValues.SetValues(updateEntity);


        public void Update(T entity) => Table.Update(entity);



        public async Task ExecuteUpdateAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpression)
        {
            await  Table.ExecuteUpdateAsync(updateExpression);
        }
    }
}
