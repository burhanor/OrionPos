using Microsoft.EntityFrameworkCore.Query;
using OrionPos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.DataAccess.Repositories
{
    public interface IRepository<T> where T: class,IEntityBase,new()
    {
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
        Task AddAsync(T entity);

        void Delete(T entity);

        Task<ICollection<T>> GetAllAsync(
                            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? order = null,
            bool enableTracking = false
            );
        Task<ICollection<T>> GetAllByPaginationAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? order = null, bool enableTracking = false, int currentPage = 1, int pageSize = 10);

        Task<T> GetAsync(
           Expression<Func<T, bool>> predicate,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           bool enableTracking = false
           );

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);
        void Update(T unchanged, T updateEntity);
        void Update(T entity);

        // Soft Delete icin
        Task ExecuteUpdateAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpression);

    }
}
