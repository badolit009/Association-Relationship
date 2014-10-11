using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEntryApp
{
    public partial class StudentEntryUI : Form
    {
        private Department aDepartment;

        public StudentEntryUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            aDepartment = new Department(codeTextBox.Text,departmentName.Text);
            MessageBox.Show("has been created");
        }

        private void studentSaveButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student(studentNameTextBox.Text, emailTextBox.Text, regNoTextBox.Text);
            string msg=aDepartment.AddStudent(aStudent);
            MessageBox.Show(msg);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            int noOfStudent = aDepartment.students.Count;
            string msg = "Dpert Code: " + aDepartment.Code + " Deprt Name: " + aDepartment.DepartmentName+"No Of Student"+noOfStudent;
            msg += "\n Student RegNo\t Name\t Email\n";
            foreach (Student aStudent in aDepartment.students)
            {
                msg += aStudent.RegNo + "\t" + aStudent.Name + "\t" + aStudent.Email+"\n";
            }
            MessageBox.Show(msg);

        }
    }
}
