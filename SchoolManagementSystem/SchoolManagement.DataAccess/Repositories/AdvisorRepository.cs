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
    public class AdvisorRepository : BaseRepository<Advisor> ,IAdvisorRepository
    {
        public AdvisorRepository(ApplicationDbContext context,ILogger<AdvisorRepository> logger) : base(context,logger) { }

        public async Task<Advisor> GetAdvisorWithMaterialsAsync(int advisorId)
        {
            return await _dbSet
                .Include(a => a.Materials)
                .FirstOrDefaultAsync(a => a.AdvisorID == advisorId);
        }

        public async Task<IEnumerable<Advisor>> GetAdvisorWithMaterialsAsync()
        {
            return await _dbSet.Include(m => m.Materials) . ToListAsync();
        }
    }
}
