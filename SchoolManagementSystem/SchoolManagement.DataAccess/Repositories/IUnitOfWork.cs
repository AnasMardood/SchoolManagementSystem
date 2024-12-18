using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
        {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        IBaseRepository<Advisor> Advisors { get; }
        IBaseRepository<Materials> Materials { get; }
        Task SaveChangesAsync();


    }
}
