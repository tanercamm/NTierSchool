using NTierSchool.Entity.Context;
using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.DAL.Concrete
{
    public class TeacherRepository : GenericRepository<Teacher>
    {
        public TeacherRepository(SchoolContext context) : base(context)
        {
        }
    }
}
