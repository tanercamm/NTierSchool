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
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<TeacherDto>> GetAllWithIncludes()
        {
            var teacherEntities = await _repository.GetAllWithIncludes();

            var list = new List<TeacherDto>();

            foreach (var teacherEntity in teacherEntities)
            {
                list.Add(new TeacherDto
                {
                    Id = teacherEntity.Id,
                    Name = teacherEntity.Name,
                    Age = teacherEntity.Age,
                    Subject = teacherEntity.Subject,
                    Class = new ClassDto
                    {
                        Id = teacherEntity.Id,
                        Name = teacherEntity.Name,
                        School = new SchoolDto
                        {
                            Id = teacherEntity.Id,
                            Name = teacherEntity.Name,
                            Address = teacherEntity.Class.School.Address
                        },
                        Teachers = teacherEntity.Class.Teachers.Select(t => new TeacherDto
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Age = t.Age,
                            Subject = t.Subject
                        }).ToList(),
                        Students = teacherEntity.Class.Students.Select(s => new StudentDto
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
