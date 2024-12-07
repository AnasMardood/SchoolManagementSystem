using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
                        Expression<Func<TEntity, bool>>? filter = null,
                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                        params Expression<Func<TEntity, object>>[]? includes);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            params Expression<Func<TEntity, object>>[]? includes);

        IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        Task<TEntity> GetByIdAsync(object id);

        TEntity GetById(object id);

        void Create(TEntity entity);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }   
}
