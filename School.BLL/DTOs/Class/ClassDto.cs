using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierSchool.BLL.DTOs.School;
using NTierSchool.BLL.DTOs.Student;
using NTierSchool.BLL.DTOs.Teacher;

namespace NTierSchool.BLL.DTOs.Class
{
    public class ClassDto : ClassBaseDto
    {
        public List<TeacherBaseDto> Teachers { get; set; }

        public SchoolBaseDto School { get; set; }

        public List<StudentBaseDto> Students { get; set; }

    }
}
