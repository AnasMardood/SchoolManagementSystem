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
    public class MaterialsRepository : BaseRepository<Materials>, IMaterialsRepository
    {
        public MaterialsRepository(ApplicationDbContext context, ILogger<MaterialsRepository> logger)
            : base(context, logger)
        {
        }

        // Get study materials by Classes
        public async Task<IEnumerable<Materials>> GetMaterialsBySemesterAsync(int classId)
        {
            return await _dbSet
                .Where(m => m.ClassID == classId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Materials>> GetMaterialsAsync()
        {
            return await _dbSet.Include(a => a.AdvisorID)
                                .Include(c => c.ClassID)
                                .ToListAsync();
        }     
        public async Task<Materials> GetMaterialsWithDetailsAsync(int materialId)
        {
            return await _dbSet.Include(a => a.Advisor)
                                .Include(c => c.Class)
                                .FirstOrDefaultAsync(m => m.MaterialID == materialId);
        }
    }
}

