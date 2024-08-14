using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.Entity.Models
{
    public class Class : BaseEntity
    {
        [Required]
        public int SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public List<Student> Students { get; set; } = new List<Student>();

        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            Teachers.ForEach(x => x.Delete());
            Students.ForEach(x => x.Delete());

            IsDeleted = true;
        }
    }
}
