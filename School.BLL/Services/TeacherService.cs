using NTierSchool.BLL.DTOs;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

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
                    Class = new ClassBaseDto()
                    {
                        Id = teacherEntity.Class.Id,
                        Name = teacherEntity.Class.Name
                    }
                });
            }
            return list;
        }
    }
}
