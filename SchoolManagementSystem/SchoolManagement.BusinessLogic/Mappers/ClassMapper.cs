using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class ClassMapper
    {
        public static ClassDTO Map(Classes classEntity)
        {
            return new ClassDTO
            {
                ClassID = classEntity.ClassID,
                ClassName = classEntity.ClassName
            };
        }

        public static List<ClassDTO> Map(IEnumerable<Classes> classes)
        {
            return classes.Select(Map).ToList();
        }
    }

}
