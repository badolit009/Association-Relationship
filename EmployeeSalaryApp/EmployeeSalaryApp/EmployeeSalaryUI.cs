using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeSalaryApp
{
    public partial class EmployeeSalaryUI : Form
    {
        private Employee anEmployee;

        public EmployeeSalaryUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Salary salary1 = new Salary();
            salary1.BasicSalary = Convert.ToDouble(basicSalaryTextBox.Text);
            salary1.MedicalAmount=Convert.ToDouble(medicalTextBox.Text);
            salary1.ConveyanceAmount=Convert.ToDouble(conveyanceTextBox.Text);

            anEmployee = new Employee();
            anEmployee.Id = idTextBox.Text;
            anEmployee.Email = emailTextBox.Text;
            anEmployee.Name = nameTextBox.Text;
            anEmployee.ASalary = salary1;
            MessageBox.Show(@"Has been created");
        }

        private void incrimentButton_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(increaseTextBox.Text);
            anEmployee.ASalary.increase(amount);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            noOfIncrimentTextBox.Text = anEmployee.ASalary.noOfIncrement.ToString();
            showBasicSalaryTextBox.Text = anEmployee.ASalary.BasicSalary.ToString();
            showMedicalTextBox.Text = anEmployee.ASalary.GetMedicalAmount().ToString();
            showConveyanceTextBox.Text = anEmployee.ASalary.GetConveyanceAmount().ToString();
            totalTextBox.Text = anEmployee.ASalary.GetTotal().ToString();
        }
    }
}
