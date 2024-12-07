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
    public class SemesterRepository : BaseRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(ApplicationDbContext context, ILogger<SemesterRepository> logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Semester>> GetSemestersWithStudentAsync()
        { 
            return await _dbSet
                .Include( s => s.StudentSemesters)
                .ToListAsync();
        }
    }
}
