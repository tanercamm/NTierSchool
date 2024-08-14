using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.Entity.Models
{
    public class School : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public List<Class> Classes { get; set; } = new List<Class>();

        public bool IsDeleted { get; private set; }
    
        public void Delete()
        {
            IsDeleted = true;
            Classes.ForEach(x => x.Delete());
        }
    }
}
