using NTierSchool.Entity.Context;
using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.DAL.Concrete
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }
    }
}
