using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierSchool.BLL.DTOs.Class;

namespace NTierSchool.BLL.DTOs.Teacher
{
    public class TeacherDto : TeacherBaseDto
    {
        public ClassBaseDto Class { get; set; }
    }
}
