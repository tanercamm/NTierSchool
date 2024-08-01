using NTierSchool.BLL.DTOs.Class;
using NTierSchool.BLL.DTOs.School;
using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Interfaces
{
    public interface ISchoolService
    {
        Task<List<SchoolDto>> GetAllWithDetails();

        Task<List<SchoolBaseDto>> GetAllAsync();

        Task<SchoolDto> GetByIdAsync(int id);

        Task AddAsync(CreateSchoolDto entity);

        Task UpdateAsync(UpdateSchoolDto entity);

        Task DeleteAsync(int id);
    }
}
