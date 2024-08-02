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

        public async Task<List<TeacherBaseDto>> GetAllAsync()
        {
            var teacherEntities = await _teacherRepository.GetAllAsync();

            var list = new List<TeacherBaseDto>();

            foreach (var teacherEntity in teacherEntities)
            {
                list.Add(new TeacherBaseDto
                {
                    Id = teacherEntity.Id,
                    Name = teacherEntity.Name,
                    Age = teacherEntity.Age,
                    Subject = teacherEntity.Subject
                });
            }
            return list;
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

        public async Task<TeacherDto> GetByIdAsync(int id)
        {
            var teacherEntity = await _teacherRepository.GetByIdWithDetails(id);

            if (teacherEntity == null)
            {
                throw new Exception("Teacher not found!");
            }

            var teacherDto = new TeacherDto
            {
                Id = teacherEntity.Id,
                Name = teacherEntity.Name,
                Age = teacherEntity.Age,
                Subject = teacherEntity.Subject,
                Class = new ClassBaseDto
                {
                    Id = teacherEntity.Class.Id,
                    Name = teacherEntity.Class.Name
                }
            };

            return teacherDto;
        }

        public async Task AddAsync(CreateTeacherDto dto)
        {
            var isClassExist = await _classRepository.AnyAsync(dto.ClassId);

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

        public async Task UpdateAsync(UpdateTeacherDto dto)
        {
            var teacherEntity = await _teacherRepository.GetByIdAsync(dto.Id);

            if (teacherEntity == null)
            {
                throw new Exception("Teacher not found!");
            }

            teacherEntity.Name = dto.Name;
            teacherEntity.Age = dto.Age;
            teacherEntity.Subject = dto.Subject;

            await _teacherRepository.UpdateAsync(teacherEntity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
