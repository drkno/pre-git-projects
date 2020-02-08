using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KnoxKonnect;

namespace ATM
{
    public partial class Account : Form
    {
        public struct acct
        {
            public double balance;
            public string password;
            public string username;
            public int accountnum;
        }

        public acct user;
        private Login main;
        public Account(Login window)
        {
            main = window;
            InitializeComponent();
        }

        private void ButtonLogoutClick(object sender, EventArgs e)
        {
            this.Hide();
            main.Logout();
        }

        public void SetUser(double bal, string usera, string pwd, int accnum)
        {
            acct usr;
            usr.balance = bal;
            usr.username = usera;
            usr.password = pwd;
            usr.accountnum = accnum;
            user = usr;

            labelBalance.Text = user.balance.ToString("c");
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            DepositWithdraw dep = new DepositWithdraw(1,user.balance,this);
            dep.Show();
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            DepositWithdraw dep = new DepositWithdraw(0, user.balance,this);
            dep.Show();
        }

        private void buttonTransferFunds_Click(object sender, EventArgs e)
        {
            DepositWithdraw dep = new DepositWithdraw(2, user.balance,this);
            dep.Show();
        }

        public void SetBalance(double bal)
        {
            user.balance = bal;
            labelBalance.Text = bal.ToString("c");
        }
    }
}
