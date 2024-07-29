using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entity.Models
{
    public class Class : BaseEntity
    {
        [Required]
        public School School { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Student> Students { get; set; }
    }
}
