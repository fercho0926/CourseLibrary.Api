﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    public class AuthorDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string MainCategory { get; set; }
    }
}
