using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATM
{
    public partial class DepositWithdraw : Form
    {
        private double balance;
        private Account wind;
        public DepositWithdraw(int mode, double bal, Account window)
        {
            InitializeComponent();
            wind = window;
            balance = bal;
            switch (mode)
            {
                case 0:
                    {
                        buttonAccept.Text = "Deposit";
                        textBoxTo.ReadOnly = true;
                        textBoxTo.Text = "Self";
                        break;
                    } 
                case 1:
                    {
                        buttonAccept.Text = "Withdraw";
                        textBoxTo.ReadOnly = true;
                        textBoxTo.Text = "Self";
                        break;
                    }
                case 2:
                    {
                        textBoxTo.Text = "";
                        buttonAccept.Text = "Transfer";
                        break;
                    }
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            double output;
            if(double.TryParse(textBoxAmount.Text,out output) == false)
            {
                MessageBox.Show("Please enter a valid dollar amount.", "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            switch (buttonAccept.Text)
            {
                case "Deposit":
                    {
                        balance += output;
                        break;
                    }
                case "Withdraw":
                    {
                        balance -= output;
                        break;
                    }
                case "Transfer":
                    {
                        MessageBox.Show("Work in progress.");
                        break;
                    }
            }

            wind.SetBalance(balance);
        }
    }
}
