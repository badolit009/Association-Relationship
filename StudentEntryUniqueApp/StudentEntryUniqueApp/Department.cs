using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntryUniqueApp
{
    class Department
    {

        private const int  MAX_REG_NO=3;
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } 
        public Department(string code, string name):this()
        {
            Code = code;
            Name = name;
        }

        public Department()
        {
            Students = new List<Student>();
        }

        public string AddStudent(Student aStudent)
        {
            if (Students.Count<MAX_REG_NO)
            {
                if (HasThisRegNoValid(aStudent.RegNo))
                {
                    return "This RegNo Already Exits In This System";
                }
                Students.Add(aStudent);
                return "Student Has been Added";
            }
            return "Overflow";
        }
        public bool HasThisRegNoValid(string regNo)
        {
            foreach (Student aStudents in Students)
            {
                if(aStudents.RegNo==regNo)
                    return true;
            }
            return false;
        }
    }
}
