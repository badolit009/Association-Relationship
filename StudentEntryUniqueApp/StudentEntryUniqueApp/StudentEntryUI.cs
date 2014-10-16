using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEntryUniqueApp
{
    public partial class StudentEntryUI : Form
    {
        private Department aDepartment;
        private Student aStudent=new Student();


        public StudentEntryUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            aDepartment = new Department(codeTextBox.Text, departmentName.Text);
            
            MessageBox.Show(@"Department Information Has Been Saved");
        }

        private void studentSaveButton_Click(object sender, EventArgs e)
        {
            aStudent = new Student(regNoTextBox.Text, studentNameTextBox.Text, emailTextBox.Text);
            string msg = aDepartment.AddStudent(aStudent); ;
            MessageBox.Show(msg);

        }


        private void showButton_Click(object sender, EventArgs e)
        {
            int noOfStudent = aDepartment.Students.Count;
            string msg ="";
            msg += "Department Name : " + aDepartment.Code + "\tName : " + aDepartment.Name + "\t Number Of Student : " + noOfStudent+"\n";
            foreach (Student aStudent in aDepartment.Students)
            {
                msg += "RegNo "+aStudent.RegNo +"\t Name : "+ aStudent.Name +"\t Email : "+ aStudent.Email+"\n";
                
            }
            MessageBox.Show(msg);
        }
    }
}
