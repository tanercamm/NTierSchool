using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs
{
    public class ClassDto : ClassBaseDto
    {
        public List<TeacherBaseDto> Teachers { get; set; } = new List<TeacherBaseDto>();

        public SchoolBaseDto School { get; set; }

        public List<StudentBaseDto> Students { get; set; } = new List<StudentBaseDto>();

    }
}
