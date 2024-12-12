using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class StudentMaterialMapper
    {
        public static StudentMaterialDTO Map(StudentMaterial studentMaterial)
        {
            return new StudentMaterialDTO
            {
                StudentID = studentMaterial.StudentID,
                MaterialID = studentMaterial.MaterialID
            };
        }

        public static List<StudentMaterialDTO> Map(IEnumerable<StudentMaterial> studentMaterials)
        {
            return studentMaterials.Select(Map).ToList();
        }
    }

}
