using NTierSchool.BLL.DTOs.School;
using NTierSchool.BLL.DTOs.Student;
using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllWithDetails();

        Task<List<StudentBaseDto>> GetAllAsync();

        Task<StudentDto> GetByIdAsync(int id);

        Task AddAsync(CreateStudentDto entity);

        Task UpdateAsync(UpdateStudentDto entity);

        Task DeleteAsync(int id);
    }
}
