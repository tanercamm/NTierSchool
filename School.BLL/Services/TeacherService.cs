using NTierSchool.BLL.DTOs.Class;
using NTierSchool.BLL.DTOs.Teacher;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Concrete;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

namespace NTierSchool.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassRepository _classRepository;

        public TeacherService(ITeacherRepository repository, IClassRepository classRepository)
        {
            _teacherRepository = repository;
            _classRepository = classRepository;
        }

        public Task<List<TeacherBaseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TeacherDto>> GetAllWithDetails()
        {
            var teacherEntities = await _teacherRepository.GetAllWithDetails();

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

        public Task<TeacherDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(CreateTeacherDto dto)
        {
            var isClassExist = await _classRepository.Any(dto.ClassId);

            if (!isClassExist)
            {
                throw new Exception("Class does not exist!");
            }

            var entity = new Teacher
            {
                Name = dto.Name,
                Age = dto.Age,
                Subject = dto.Subject,
                ClassId = dto.ClassId
            };

            await _teacherRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateTeacherDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
