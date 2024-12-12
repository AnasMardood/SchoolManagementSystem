using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task<Student> GetStudentWithDetailsAsync(int StudentId);
        Task<IEnumerable<Student>> GetStudentByClassAsync(int ClassId);

    }
}
