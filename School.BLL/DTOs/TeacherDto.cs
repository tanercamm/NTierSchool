using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs
{
    public class TeacherDto : TeacherBaseDto
    {
        public ClassBaseDto Class { get; set; }
    }
}
