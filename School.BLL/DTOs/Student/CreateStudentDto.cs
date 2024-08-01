using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs.Student
{
    public class CreateStudentDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int ClassId { get; set; }
    }
}
