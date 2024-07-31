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
    public class SchoolService : BaseService<School>, ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository repository) : base(repository)
        {
            _schoolRepository = repository;
        }

        public async Task<List<SchoolDto>> GetAllWithIncludes()
        {
            var schoolEntities = await _schoolRepository.GetAllWithIncludes();

            var list = new List<SchoolDto>();

            foreach (var schoolEntity in schoolEntities)
            {
                list.Add(new SchoolDto
                {
                    Id = schoolEntity.Id,
                    Name = schoolEntity.Name,
                    Address = schoolEntity.Address,
                    Classes = schoolEntity.Classes.Select(c => new ClassDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        School = new SchoolDto
                        {
                            Id = schoolEntity.Id,
                            Name = schoolEntity.Name,
                            Address = schoolEntity.Address
                        },
                        Teachers = c.Teachers.Select(t => new TeacherDto
                        {
                            Id= t.Id,
                            Name = t.Name,
                            Age = t.Age,
                            Subject = t.Subject
                        }).ToList(),
                        Students = c.Students.Select(s => new StudentDto
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Age= s.Age
                        }).ToList()
                    }).ToList()
                });
            }

            return list;
        }
    }
}
