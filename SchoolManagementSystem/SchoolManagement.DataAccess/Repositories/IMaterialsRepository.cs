using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public interface IMaterialsRepository  : IBaseRepository<Materials>
    {
        Task<IEnumerable<Materials>> GetMaterialsBySemesterAsync(int classId);
   
    }
}
