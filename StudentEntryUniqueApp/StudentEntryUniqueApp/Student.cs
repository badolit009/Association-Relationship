﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntryUniqueApp
{
    class Student
    {
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public Student(string regNo, string name, string email):this()
        {
            RegNo = regNo;
            Name = name;
            Email = email;
        }

        public Student()
        {

        }
    }
}
