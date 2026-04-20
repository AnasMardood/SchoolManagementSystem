using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.DataAccess.Data;
using SchoolManagement.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public class StudentMarkRepository : BaseRepository<StudentMark>, IStudentMarkRepository
    {
        public StudentMarkRepository(ApplicationDbContext context, ILogger<StudentMarkRepository> logger)
            : base(context, logger)
        {
        }

        public async Task<List<StudentMark>> GetAllStudentMarksWithDetailsAsync()
        {
            return await _dbSet
                .Include(sm => sm.Student)
                .Include(sm => sm.Material)
                .ToListAsync();
        }

        public async Task<StudentMark?> GetStudentMarkByIdWithDetailsAsync(int gradeId)
        {
            return await _dbSet
                .Include(sm => sm.Student)
                .Include(sm => sm.Material)
                .FirstOrDefaultAsync(sm => sm.GradeID == gradeId);
        }
    }

    public interface IStudentMarkRepository : IBaseRepository<StudentMark>
    {
        Task<List<StudentMark>> GetAllStudentMarksWithDetailsAsync();
        Task<StudentMark> GetStudentMarkByIdWithDetailsAsync(int gradeId);
    }
}
