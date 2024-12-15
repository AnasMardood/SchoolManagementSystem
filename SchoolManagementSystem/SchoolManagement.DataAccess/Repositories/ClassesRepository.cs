using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public class ClassesRepository : BaseRepository<Classes> , IClassesRepository
    {

        public ClassesRepository(ApplicationDbContext context, ILogger<ClassesRepository> logger)
        : base(context, logger)
        {
        }

        public async Task<IEnumerable<Classes>> GetAllClasses()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Classes>> GetClassesWithStudentAsync()
        {
            return await _dbSet
                .Include(c => c.Students)
                .ToListAsync();
        }
    }
}
