using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs
{
    public class ClassDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TeacherDto> Teachers { get; set; } = new List<TeacherDto>();

        public SchoolDto School { get; set; }

        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
        
    }
}
