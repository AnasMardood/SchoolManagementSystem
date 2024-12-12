using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class MaterialsMapper
    {
        public static MaterialsDTO Map(Materials material)
        {
            return new MaterialsDTO
            {
                MaterialID = material.MaterialID,
                LessonsName = material.LessonsName,
                CreditHours = material.CreditHours,
                AdvisorID = material.AdvisorID,
                ClassID = material.ClassID
            };
        }

        public static List<MaterialsDTO> Map(IEnumerable<Materials> materials)
        {
            return materials.Select(Map).ToList();
        }
    }

}
