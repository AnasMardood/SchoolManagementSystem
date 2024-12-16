using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Repositories
{
    public interface IAdvisorRepository : IBaseRepository<Advisor>
    {
        Task<Advisor> GetAdvisorWithMaterialsAsync(int advisorId);
        Task<IEnumerable<Advisor>> GetAdvisorWithMaterialsAsync();
    }
}
