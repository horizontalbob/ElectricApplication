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
        public string deposit(double dblDepositAmount)
        {
            if ((this.dblBalance - dblDepositAmount) < 0) return "Not enough owed on account to make this payment";
            this.dblBalance -= dblDepositAmount;
            return "Payment accepted";
        }
        public string recordUnits(double dblUnitsUsed)
        {
            if(dblUnitsUsed > 0) return "Current value unchanged, please review your input";
            this.dblUnits += dblUnitsUsed;
            this.dblBalance += dblUnits * dblUnitCost;
            return "Value successfully updated";
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
            this.dblUnitCost = dblNewUnitCost;
            this.dblBalance = dblUnits * dblUnitCost;
        }
    }
}
