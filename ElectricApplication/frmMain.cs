using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ElectricApplication
{
    public partial class frmMain : Form
    {
        private Account[] data;  // Array for storing ElectricAccount objects
        private const int MAX = 5;  // Maximum number of ElectricAccount objects
        private int nextRef = 1;    // Used for assigning the next ElectricAccount reference number
        private int count = 0;      // To keep track of number of ElectricAccount
        public frmMain()
        {
            data = new Account[MAX]; // initialise storage for ElectricAccount objects
            InitializeComponent();
        }
        private void listAccounts()
        {
            lstAccounts.Items.Clear();
            for (int index = 0; index < count; index++)
            {
                Account temp = data[index];
                lstAccounts.Items.Add(temp.getAccRefNo() + " " +
                temp.getName());
            }
        }
        private void clearAcctFields()
        {
            txtAdd.Text = "";
            txtBalance.Text = "";
            txtName.Text = "";
            txtPayment.Text = "";
            txtRef.Text = "";
            txtSetUnits.Text = "";
            txtUnitCost.Text = "";
            txtUnitsUsed.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String address = txtAdd.Text;
            if (count < MAX)
            {
                Account temp = new Account(nextRef, name, address);
                data[count] = temp;
                lstAccounts.Items.Add(nextRef + " " + name);
                count++;
                nextRef++;
                clearAcctFields();
                lblOutput.Text = "New account added.";
            }
        }

        /// <summary>
        /// Reorders the base array and redisplays
        /// </summary>
        private void sortAccounts()
        {
            if (radioButton1.Checked)
            {
                data = data.Where(a => a != null).OrderByDescending(s => s.getBalance()).ToArray();
            }
            else
            {
                data = data.Where(a => a != null).OrderBy(s => s.getAccRefNo()).ToArray();
            }

            Array.Resize<Account>(ref data, 5);
            listAccounts();
        }
        private void btnRecord_Click(object sender, EventArgs e)
        {
            double value;
            if (data != null && data.Length != 0)
            {
                try
                {
                    var account = data[lstAccounts.SelectedIndex];
                    double.TryParse(txtRecUnits.Text, out value);
                    lblOutput.Text = account == null ? "Please select an account" : lblOutput.Text = account.recordUnits(value);
                    txtUnitsUsed.Text = account.getUnits().ToString();
                    txtBalance.Text = account.getBalance().ToString();
                }
                catch// don't really care about the exception so just swallow it
                {
                    lblOutput.Text = "Please select an account";
                }
            }
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            double value;
            if (!string.IsNullOrEmpty(txtPayment.Text))
            {
                try
                {
                    var account = data[lstAccounts.SelectedIndex];
                    double.TryParse(txtPayment.Text, out value);
                    account.deposit(value);
                    txtUnitCost.Text = account.getUnitCost().ToString(); //get the value and update the textbox
                    txtBalance.Text = account.getBalance().ToString();
                }
                catch// don't really care about the exception so just swallow it
                {
                    lblOutput.Text = "Please select an account";
                }
            }
            else
            {
                lblOutput.Text = "Please enter a value";
            }
        }
        private void btnSetUnits_Click(object sender, EventArgs e)
        {
            double value;
            if (!string.IsNullOrEmpty(txtSetUnits.Text))
            {
                try
                {
                    var account = data[lstAccounts.SelectedIndex];
                    double.TryParse(txtSetUnits.Text, out value);
                    account.updateUnitCost(value);
                    txtUnitCost.Text = account.getUnitCost().ToString(CultureInfo.CurrentCulture); //get the value and update the textbox
                    txtBalance.Text = account.getBalance().ToString(CultureInfo.CurrentCulture);
                }
                catch// don't really care about the exception so just swallow it
                {
                    lblOutput.Text = "Please select an account";
                }
            }
            else
            {
                lblOutput.Text = "Please enter a value";
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            // code for sort button
            lblOutput.Text = "Press this button to sort accounts";
            sortAccounts();
            listAccounts();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            data = data.Where(d => d != null && d.getBalance() > 0).ToArray(); //assuming minus value (account in credit) is also valid to close. see below if this assumption is wrong
            // data = data.Where(d => d != null && d.getBalance() != 0).ToArray(); 
            Array.Resize<Account>(ref data, 5);
            recalculateClassVars();
            sortAccounts();
        }
        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected account and add details to form
            int index = lstAccounts.SelectedIndex;
            if (index >= 0)
            {
                Account temp = data[index];
                txtRef.Text = temp.getAccRefNo() + "";
                txtName.Text = temp.getName() + "";
                txtAdd.Text = temp.getAddress();
                txtUnitsUsed.Text = temp.getUnits().ToString(CultureInfo.CurrentCulture);
                txtUnitCost.Text = temp.getUnitCost().ToString(CultureInfo.CurrentCulture);
                txtBalance.Text = temp.getBalance().ToString(CultureInfo.CurrentCulture);
                lblOutput.Text = "You will need to add information to the other Textbox items";
            }
        }

        private void recalculateClassVars()
        {
            var tempCount = data.Count(d => d != null);
            count = tempCount; //not sure about using count as a class level variable. Should really be .Length when needed
            nextRef = tempCount + 1; //I feel nextRef should also be calculated
        }
    }
}
