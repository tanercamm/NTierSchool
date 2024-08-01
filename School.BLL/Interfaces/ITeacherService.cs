using NTierSchool.BLL.DTOs.School;
using NTierSchool.BLL.DTOs.Teacher;

namespace NTierSchool.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetAllWithDetails();

        Task<List<TeacherBaseDto>> GetAllAsync();

        Task<TeacherDto> GetByIdAsync(int id);

        Task AddAsync(CreateTeacherDto entity);

        Task UpdateAsync(UpdateTeacherDto entity);

        Task DeleteAsync(int id);
    }
}
