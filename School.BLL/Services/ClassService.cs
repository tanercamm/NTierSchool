using NTierSchool.BLL.DTOs;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

namespace NTierSchool.BLL.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository repository) : base(repository)
        {
            _classRepository = repository;
        }

        public async Task<List<ClassDto>> GetAllWithIncludes()
        {
            var classEntities = await _classRepository.GetAllWithIncludes();

            var list = new List<ClassDto>();


            foreach (var classEntity in classEntities)
            {

                list.Add(new ClassDto
                {
                    Id = classEntity.Id,
                    Name = classEntity.Name,
                    School = new SchoolBaseDto
                    {
                        Id = classEntity.School.Id,
                        Name = classEntity.School.Name,
                        Address = classEntity.School.Address
                    },
                    Teachers = classEntity.Teachers.Select(y => new TeacherBaseDto
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Age = y.Age,
                        Subject = y.Subject
                    }).ToList(),
                    Students = classEntity.Students.Select(y => new StudentBaseDto
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Age = y.Age
                    }).ToList()
                });
            }
            return list;
        }
    }
}
