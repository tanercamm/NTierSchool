using NTierSchool.BLL.DTOs;
using NTierSchool.BLL.DTOs.Class;
using NTierSchool.BLL.DTOs.School;
using NTierSchool.BLL.DTOs.Student;
using NTierSchool.BLL.DTOs.Teacher;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Concrete;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

namespace NTierSchool.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public StudentService(IStudentRepository repository, IClassRepository classRepository)
        {
            _studentRepository = repository;
            _classRepository = classRepository;
        }

        public async Task<List<StudentBaseDto>> GetAllAsync()
        {
            var studentEntities = await _studentRepository.GetAllAsync();

            var list = new List<StudentBaseDto>();

            foreach (var studentEntity in studentEntities)
            {
                list.Add(new StudentBaseDto
                {
                    Id = studentEntity.Id,
                    Name = studentEntity.Name,
                    Age = studentEntity.Age
                });
            }
            return list;
        }

        public async Task<List<StudentDto>> GetAllWithDetails()
        {
            var studentEntities = await _studentRepository.GetAllWithDetails();

            var list = new List<StudentDto>();

            foreach (var studentEntity in studentEntities)
            {
                list.Add(new StudentDto
                {
                    Id = studentEntity.Id,
                    Name = studentEntity.Name,
                    Age = studentEntity.Age,
                    Class = new ClassDto
                    {
                        Id = studentEntity.Class.Id,
                        Name = studentEntity.Class.Name,
                        School = new SchoolBaseDto
                        {
                            Id = studentEntity.Class.School.Id,
                            Name = studentEntity.Class.School.Name,
                            Address = studentEntity.Class.School.Address
                        },
                        Teachers = studentEntity.Class.Teachers.Select(t => new TeacherBaseDto
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Age = t.Age,
                            Subject = t.Subject
                        }).ToList(),
                        Students = studentEntity.Class.Students.Select(s => new StudentBaseDto
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Age = s.Age
                        }).ToList()
                    }
                });
            }
            return list;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var studentEntity = await _studentRepository.GetByIdWithDetails(id);

            if (studentEntity == null)
            {
                throw new Exception("Student not found!");
            }

            var studentDto = new StudentDto
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                Age = studentEntity.Age,
                Class = new ClassBaseDto
                {
                    Id = studentEntity.Class.Id,
                    Name = studentEntity.Class.Name
                }
            };

            return studentDto;
        }

        public async Task AddAsync(CreateStudentDto dto)
        {
            var isClassExist = await _classRepository.AnyAsync(dto.ClassId);

            if (!isClassExist)
            {
                throw new Exception("Class does not exist!");
            }

            var entity = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                ClassId = dto.ClassId
            };

            await _studentRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(UpdateStudentDto dto)
        {
            var studentEntity = await _studentRepository.GetByIdAsync(dto.Id);

            if (studentEntity == null)
            {
                throw new Exception("Student not found!");
            }

            studentEntity.Name = dto.Name;
            studentEntity.Age = dto.Age;

            await _studentRepository.UpdateAsync(studentEntity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
