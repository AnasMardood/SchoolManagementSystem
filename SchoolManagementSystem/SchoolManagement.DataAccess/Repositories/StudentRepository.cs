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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context, ILogger<StudentRepository> logger)
            : base(context, logger)
    {
    }

        public async Task<Student> GetStudentWithDetailsAsync(int studentId)
    {
        return await _dbSet
            .Include(s => s.Class)
            .Include(s => s.StudentMaterials)
            .FirstOrDefaultAsync(s => s.StudentID == studentId);
    }

    public async Task<IEnumerable<Student>> GetStudentByClassAsync(int classId)
    {
        return await _dbSet
            .Where(s => s.ClassID == classId)
            .ToListAsync();
    }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _dbSet
                  .Include(s => s.Class)
                  .ToListAsync();
        }
    }
    }

