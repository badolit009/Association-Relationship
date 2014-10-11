using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryApp
{
    class Salary
    {
        public double BasicSalary { set; get; }
        public double MedicalAmount {  set; get; }
        public double ConveyanceAmount {  set; get; }
        public int noOfIncrement { private set; get; }
        public double Total { set; get; }

        public void increase(double noOfPercent)
        {
            double amountToBeIncreased = (BasicSalary*noOfPercent)/100;
            BasicSalary += amountToBeIncreased;
            noOfIncrement++;

        }
        public double GetMedicalAmount()
        {
            return (BasicSalary * MedicalAmount) / 100;
        }

        public double GetConveyanceAmount()
        {
            return (BasicSalary * ConveyanceAmount) / 100;
        }

        public double GetTotal()
        {
            return BasicSalary + GetMedicalAmount() + GetConveyanceAmount();
        }
    }
}
