using NTierSchool.BLL.DTOs;
using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Models;

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
                    Classes = schoolEntity.Classes.Select(c => new ClassBaseDto
                    {
                        Id= c.Id,
                        Name = c.Name
                    }).ToList()
                });
            }

            return list;
        }
    }
}
