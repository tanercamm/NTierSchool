 using NTierSchool.BLL.DTOs.Class;
using NTierSchool.BLL.DTOs.School;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Concrete;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

namespace NTierSchool.BLL.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IClassRepository _classRepository;

        public SchoolService(ISchoolRepository schoolRepository, IClassRepository classRepository)
        {
            _schoolRepository = schoolRepository;
            _classRepository = classRepository;
        }

        public async Task<List<SchoolBaseDto>> GetAllAsync()
        {
            var schoolEntities = await _schoolRepository.GetAllAsync();

            var list = new List<SchoolBaseDto>();

            foreach (var schoolEntity in schoolEntities.Where(s => !s.IsDeleted))
            {
                list.Add(new SchoolBaseDto
                {
                    Id = schoolEntity.Id,
                    Name = schoolEntity.Name,
                    Address = schoolEntity.Address
                });
            }
            return list;
        }

        public async Task<List<SchoolDto>> GetAllWithDetails()
        {
            var schoolEntities = await _schoolRepository.GetAllWithDetails();

            var list = new List<SchoolDto>();

            foreach (var schoolEntity in schoolEntities.Where(s => !s.IsDeleted))
            {
                list.Add(new SchoolDto
                {
                    Id = schoolEntity.Id,
                    Name = schoolEntity.Name,
                    Address = schoolEntity.Address,
                    Classes = schoolEntity.Classes
                        .Where(c => !c.IsDeleted)
                        .Select(c => new ClassBaseDto
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList()
                });
            }

            return list;
        }

        public async Task<SchoolDto> GetByIdAsync(int id)
        {
            var schoolEntity = await _schoolRepository.GetByIdWithDetails(id);

            if (schoolEntity == null || schoolEntity.IsDeleted)
            {
                throw new Exception("School not found!");
            }

            var schoolDto = new SchoolDto
            {
                Id = schoolEntity.Id,
                Name = schoolEntity.Name,
                Address = schoolEntity.Address,
                Classes = schoolEntity.Classes
                    .Where(c => !c.IsDeleted)
                    .Select(c => new ClassBaseDto
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList()
            };

            return schoolDto;
        }

        public async Task AddAsync(CreateSchoolDto dto)
        {
            var entity = new School
            {
                Name = dto.Name,
                Address = dto.Address
            };

            await _schoolRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(UpdateSchoolDto dto)
        {
            var schoolEntity = await _schoolRepository.GetByIdAsync(dto.Id);

            if (schoolEntity == null || schoolEntity.IsDeleted)
            {
                throw new Exception("School not found!");
            }

            schoolEntity.Name = dto.Name;
            schoolEntity.Address = dto.Address;

            await _schoolRepository.UpdateAsync(schoolEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var school = await _schoolRepository.GetByIdAsync(id);

            if (school == null || school.IsDeleted)
            {
                throw  new Exception($"Unable to delete {id}");
            }

            school.Delete();

            await _schoolRepository.UpdateAsync(school);

            var classList = await _classRepository.GetAllBySchoolIdWithDetails(school.Id);

            classList.ForEach(x => x.Delete());

            foreach (var classEntity in classList)
            {
                await _classRepository.UpdateAsync(classEntity);
            }

            await _schoolRepository.SaveChangesAsync();
        }
    }
}
