using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    internal interface IUnitOfWork : IDisposable
        {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        Task SaveChangesAsync();


    }
}
