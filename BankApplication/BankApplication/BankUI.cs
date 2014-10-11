using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplication
{
    public partial class BankUI : Form
    {
        private Customer aCustomer;

        public BankUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Account account1 = new Account();
            account1.Number = accountNumberEntryTextBox.Text;
            account1.OpeningDate = openingDateEntryTextBox.Text;

            aCustomer = new Customer();
            aCustomer.Name = customerNameEntryTextBox.Text;
            aCustomer.Email = emailEntryTextBox.Text;
            aCustomer.AnAccount = account1;
            MessageBox.Show("created");

        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            aCustomer.AnAccount.GetDeposit(Convert.ToDouble(amountTextBox.Text));
            MessageBox.Show(@"has been deposited");

        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            aCustomer.AnAccount.GetWithdraw(Convert.ToDouble(amountTextBox.Text));
            MessageBox.Show(@"has been withdraw");
        }

        private void showDetailsButton_Click(object sender, EventArgs e)
        {
            customerNameDisplayTextBox.Text = aCustomer.Name;
            emailDisplayTextBox.Text = aCustomer.Email;
            accountNumberDisplayTextBox.Text = aCustomer.AnAccount.Number;
            openingDateDisplayTextBox.Text = aCustomer.AnAccount.OpeningDate;
            balanceTextBox.Text = aCustomer.AnAccount.Balance.ToString();
        }
    }
}
