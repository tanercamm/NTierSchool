using NTierSchool.BLL.DTOs;
using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Interfaces
{
    public interface IStudentService : IBaseService<Student>
    {
        Task<List<StudentDto>> GetAllWithIncludes();
    }
}
