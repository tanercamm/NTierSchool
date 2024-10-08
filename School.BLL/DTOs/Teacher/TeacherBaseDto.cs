﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs.Teacher
{
    public class TeacherBaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
