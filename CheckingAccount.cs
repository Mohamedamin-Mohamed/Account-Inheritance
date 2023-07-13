using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Inheritance
{
    internal class CheckingAccount : Account
    {
        private decimal fee;
        public CheckingAccount(decimal balance, decimal fee) :
            base(balance)
        {
            //check to see whether fee passed is less than zero
            if (fee < 0)
            {
                throw new ArgumentOutOfRangeException($"Value {fee} is out of range!!!");
            }
            this.fee = fee;
        }
        //override the base Credit and Debit methods by susbtracting the fee from the account balance
        public override void Credit(decimal add)
        {
            base.Credit(add-fee);
        }
        public override void Debit(decimal withdraw)
        {
            base.Debit(withdraw+fee);
        }
    }
    }
