using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierSchool.BLL.DTOs.Class;

namespace NTierSchool.BLL.DTOs.School
{
    public class SchoolDto : SchoolBaseDto
    {
        public List<ClassBaseDto> Classes { get; set; }
    }
}
