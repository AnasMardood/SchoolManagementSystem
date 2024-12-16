using Microsoft.Extensions.Logging;
using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.BusinessLogic.Mappers;
using SchoolManagement.DataAccess.Models;
using SchoolManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repository, ILogger<StudentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<StudentDTO> GetStudentWithDetailsAsync(int studentId)
        {
            try
            {
                var student = await _repository.GetStudentWithDetailsAsync(studentId);
                return StudentMapper.Map(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching details for Student ID {studentId}.");
                throw;
            }
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsByClassAsync(int classId)
        {
            try
            {
                var students = await _repository.GetStudentByClassAsync(classId);
                return students.Select(StudentMapper.Map).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching students for Class ID {classId}.");
                throw;
            }
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudent()
        {
            try
            {
                var students = await _repository.GetAllStudent();
                return students.Select(StudentMapper.Map).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching students");
                throw;
            }
        }

        public async Task CreateStudentAsync(StudentDTO student)
        {
            try
            {
                var _student = StudentMapper.Map(student);
                _student.ClassID= student.ClassID;

               _repository.Create(_student);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while create student");
                throw;
            }

        }

        public async Task DeletStudentAsync(int studentId)
        {
            try
            {

                var student = _repository.GetAllStudent();
                foreach(var Dstudent in await student)
                {
                    if(Dstudent.StudentID == studentId) { _repository.Delete(Dstudent); }
                }
                await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while delete student");
                throw;
            }
        }

        public async Task EditStudentAsync(StudentDTO studentDTO)
        {
            try
            {
                var student =  StudentMapper.Map(studentDTO);
                if (student == null)
                {
                    throw new Exception("Student not found");
                }
                student.FirstName = studentDTO.FirstName;
                student.LastName = studentDTO.LastName;
                student.MotherName = studentDTO.MotherName;
                student.FatherName = studentDTO.FatherName;
                student.BirthDate = studentDTO.BirthDate;
                student.EnrollementDate = studentDTO.EnrollementDate;
                student.ParentPhone = studentDTO.ParentPhone;
                student.StudentPhone = studentDTO.StudentPhone;
                student.Gender = studentDTO.Gender;
                student.Address = studentDTO.Address;
                student.Status = studentDTO.Status;
                student.ProfilePicture = studentDTO.ProfilePicture;
                student.Nationality = studentDTO.Nationality;
                student.ClassID = studentDTO.ClassID;

                _repository.Update(student);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating student");
                throw;
            }

        }
    }
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudent();
        Task CreateStudentAsync(StudentDTO student);
        Task<StudentDTO> GetStudentWithDetailsAsync(int studentId);
        Task<IEnumerable<StudentDTO>> GetStudentsByClassAsync(int classId);
        Task DeletStudentAsync(int studentId);
        Task EditStudentAsync(StudentDTO studentDTO);
    }
}
