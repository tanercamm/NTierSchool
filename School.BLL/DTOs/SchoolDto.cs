using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs
{
    public class SchoolDto : SchoolBaseDto
    {
        public List<ClassBaseDto> Classes { get; set; }
    }
}
