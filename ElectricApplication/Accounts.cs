using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ElectricApplication
{
    class Account
    {
        private int intAccRefNo;  //  - the account reference number
        private String strName;     //  - the name of the account holder
        private String strAddress;  //  - the address of the account holder
        private double dblBalance;  //  - the balance of the account(in £)
        private double dblUnits;  //  - the current quantity of units used
        private double dblUnitCost = 0.02; //   - the price per unit[initialised = 0.02]
        private Boolean boolActive; //  - indicates if the account is active
        // behaviour methods
        public Account(int intNewAccRefNo, String strNewName, String
            strNewAddress)
        {
            intAccRefNo = intNewAccRefNo;
            strName = strNewName;
            strAddress = strNewAddress;
            dblBalance = 0.0;
            dblUnits = 0.0;
            boolActive = true;
        }
        public void deposit(double dblDepositAmount)
        {
            // add code for deposit here
        }
        public string recordUnits(double dblUnitsUsed)
        {
            this.dblUnits += dblUnitsUsed;
            return dblUnitsUsed != 0 ? "Value successfully updated" : "Current value unchanged, please review your input";
        }
        public int getAccRefNo()
        {
            return intAccRefNo;
        }
        public String getName()
        {
            return strName;
        }
        public String getAddress()
        {
            return strAddress;
        }
        public double getBalance()
        {
            return dblBalance;
        }
        public double getUnitCost()
        {
            return dblUnitCost;
        }
        public double getUnits()
        {
            return dblUnits;
        }
        public void updateUnitCost(double dblNewUnitCost)
        {
            // add code for updateUnitCost here
        }
        public Boolean closeAccount()
        {
            // add code for closeAccount here - return true if successfully closed
            // and false otherwise
            return false;
        }
        public Boolean isActive()
        {
            return boolActive;
        }
    }
}
