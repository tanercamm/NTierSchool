using NTierSchool.BLL.DTOs.Class;

namespace NTierSchool.BLL.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassDto>> GetAllWithDetails();

        Task<List<ClassBaseDto>> GetAllAsync();

        Task<ClassDto> GetByIdAsync(int id);

        Task AddAsync(CreateClassDto entity);

        Task UpdateAsync(UpdateClassDto entity);

        Task DeleteAsync(int id);
    }
}
