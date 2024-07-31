using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs
{
    public class SchoolDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public List<ClassDto> Classes { get; set; } = new List<ClassDto>();
    }
}
