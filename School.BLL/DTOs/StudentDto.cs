using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public ClassDto Classes { get; set; }
    }
}
