﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.DTOs.School
{
    public class CreateSchoolDto
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
