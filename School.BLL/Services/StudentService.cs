using NTierSchool.BLL.DTOs;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentDto>> GetAllWithIncludes()
        {
            var studentEntities = await _repository.GetAllWithIncludes();

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
                        School = new SchoolDto
                        {
                            Id = studentEntity.Class.School.Id,
                            Name = studentEntity.Class.School.Name,
                            Address = studentEntity.Class.School.Address
                        },
                        Teachers = studentEntity.Class.Teachers.Select(t => new TeacherDto
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Age = t.Age,
                            Subject = t.Subject
                        }).ToList(),
                        Students = studentEntity.Class.Students.Select(s => new StudentDto
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
    }
}
