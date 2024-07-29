using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entity.Models
{
    public class Student : BaseEntity
    {
        [Required]
        public Class Class { get; set; }

        [Required]
        public int Age { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}
