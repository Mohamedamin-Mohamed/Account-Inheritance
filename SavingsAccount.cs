using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Inheritance
{
    internal class SavingsAccount : Account
    {
         decimal rate;
        public SavingsAccount(decimal balance, decimal rate):
            base(balance)
        {
            //check to see whether rate passed is less than zero or greater than one
            if (rate < 0 || rate > 1)
            {
                throw new ArgumentOutOfRangeException($"Value {rate} must be in the range zero - one!!!");
            }
            this.rate = rate;
        }
        public decimal CalculateInterest()
        {
            return this.rate * base.AccountBalance;
        }
       
    }
}
