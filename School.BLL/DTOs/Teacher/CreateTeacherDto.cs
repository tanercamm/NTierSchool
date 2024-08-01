using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs.Teacher
{
    public class CreateTeacherDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Subject { get; set; }

        public int ClassId { get; set; }
    }
}
