using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs.Teacher
{
    public class UpdateTeacherDto : CreateTeacherDto
    {
        public int Id { get; set; }
    }
}
