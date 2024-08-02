using NTierSchool.BLL.DTOs.Class;
using NTierSchool.BLL.DTOs.School;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

namespace NTierSchool.BLL.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository repository)
        {
            _schoolRepository = repository;
        }

        public async Task<List<SchoolBaseDto>> GetAllAsync()
        {
            var schoolEntities = await _schoolRepository.GetAllAsync();

            var list = new List<SchoolBaseDto>();

            foreach (var schoolEntity in schoolEntities)
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

            foreach (var schoolEntity in schoolEntities)
            {
                list.Add(new SchoolDto
                {
                    Id = schoolEntity.Id,
                    Name = schoolEntity.Name,
                    Address = schoolEntity.Address,
                    Classes = schoolEntity.Classes.Select(c => new ClassBaseDto
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

            if (schoolEntity == null)
            {
                throw new Exception("School not found!");
            }

            var schoolDto = new SchoolDto
            {
                Id = schoolEntity.Id,
                Name = schoolEntity.Name,
                Address = schoolEntity.Address,
                Classes = schoolEntity.Classes.Select(c => new ClassBaseDto
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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateSchoolDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
