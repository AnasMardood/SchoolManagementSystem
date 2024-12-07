using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public class _UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;



        public _UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class
        {
            IBaseRepository<TEntity> repo = new BaseRepository<TEntity>(_context);
            return repo;
        }
    }
}
