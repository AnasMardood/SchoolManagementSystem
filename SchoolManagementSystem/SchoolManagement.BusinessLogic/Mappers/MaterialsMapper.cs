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
                ClassID = material.ClassID,
                AdvisorID= material.AdvisorID,
            };
        }

        public static List<MaterialsDTO> Map(IEnumerable<Materials> materials)
        {
            return materials.Select(Map).ToList();
        }
        public static Materials Map(MaterialsDTO materialsDTO)
        {
            return new Materials
            {
                MaterialID = materialsDTO.MaterialID,
                LessonsName = materialsDTO.LessonsName,
                CreditHours = materialsDTO.CreditHours,
                ClassID = materialsDTO.ClassID,
                AdvisorID = materialsDTO.AdvisorID,
            };
        }

        public static List<Materials> Map(IEnumerable<MaterialsDTO> materials)
        {
            return materials.Select(Map).ToList();
        }
    }

}
