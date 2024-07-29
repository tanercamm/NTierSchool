using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.Entity.Models
{
    public class Teacher : BaseEntity
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public int Age { get; set; }

        public int? ClassId { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }
    }
}
