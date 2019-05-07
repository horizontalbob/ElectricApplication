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
        private void sortAccounts()
        {
            if (radioButton1.Checked)
            {
                data = data.Where(a => a != null).OrderBy(s => s.getBalance()).ToArray();
            }
            else
            {
                data = data.Where(a => a != null).OrderBy(s => s.getAccRefNo()).ToArray();
            }
        }
        private void btnRecord_Click(object sender, EventArgs e)
        {
            lstAccounts.SelectedItems
            lblOutput.Text = "Pressing this button should record units used";
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            // code for recording a payment .. TO DO
            lblOutput.Text = "Pressing this button should record a payment";
        }
        private void btnSetUnits_Click(object sender, EventArgs e)
        {
            // code for set units .. TO DO
            lblOutput.Text = "Pressing this button should set price per unit";
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
            // code for Close account button .. TO DO
            lblOutput.Text = "Press this button to close an account";
        }
        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get selected account and add details to form
            int index = lstAccounts.SelectedIndex;
            Account temp = data[index];
            txtRef.Text = temp.getAccRefNo() + "";
            txtName.Text = temp.getName() + "";
            txtAdd.Text = temp.getAddress();
            txtUnitsUsed.Text = temp.getUnits().ToString(CultureInfo.CurrentCulture);
            txtUnitCost.Text = temp.getUnitCost().ToString(CultureInfo.CurrentCulture);
            txtBalance.Text = temp.getBalance().ToString(CultureInfo.CurrentCulture);
            // some more to do here to complete this .. TO DO
            lblOutput.Text = "You will need to add information to the other Textbox items";
        }
    }
}
