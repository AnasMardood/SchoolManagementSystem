using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class SemesterMapper
    {
        public static SemesterDTO Map(Semester semester)
        {
            return new SemesterDTO
            {
                SemesterId = semester.SemesterId,
                SemesterName = semester.SemesterName
            };
        }

        public static List<SemesterDTO> Map(IEnumerable<Semester> semesters)
        {
            return semesters.Select(Map).ToList();
        }
    }

}
