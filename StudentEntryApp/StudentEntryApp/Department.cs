using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntryApp
{
    class Department
    {
        private const int MAX_NO_OF_STUDENT=2;
        public string Code { set; get; }
        public string DepartmentName { set; get; }
        public List<Student> students { set; get; }

        public Department(string code,string departmentName):this()
        {
            Code = code;
            DepartmentName = departmentName;
        }

        public Department()
        {
            students = new List<Student>();
        }

        public string AddStudent(Student student)
        {
            if (students.Count < MAX_NO_OF_STUDENT)
            {
                students.Add(student);
                return "Added";
            }
            else
            {
                return "OverFlow";
            }

        }

    }
}
