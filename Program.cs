using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Testing for base class methods
                Console.WriteLine("Base class Account");
                var account = new Account(5000);
                account.Credit(1200.34m);
                account.Debit(200);
                account.Debit(104.43m);
                Console.WriteLine($"Ending balance is {account.AccountBalance:c}");
                Console.WriteLine();

                //Testing for savings class method
                Console.WriteLine("Savings Account class");

                // var account2 = new SavingsAccount(900, -3.5m);
                //check to see whether the constructor can take a negative interest rate

                // var account2 = new SavingsAccount(-9000, 0.08m);
                //check to see if balance can be negative

                var account2 = new SavingsAccount(9000, 0.08m);
                decimal interestEarned;
                interestEarned = account2.CalculateInterest();
                Console.WriteLine($"Total interest earned is {interestEarned:c}");
                account2.Credit(interestEarned);
                Console.WriteLine($"Ending balance is {account2.AccountBalance:c}");
                Console.WriteLine();

                //Testing for checking class methods
                Console.WriteLine("Checking Account class");

                //var account3 = new CheckingAccount(300, -3.9);
                //check to see if the constructor will throw an exception

                var account3 = new CheckingAccount(4000.45m, 8.4m);
                var account4 = new CheckingAccount(2099, 0.34m);
                account3.Credit(55.25m);
                account3.Debit(933.55m);
                Console.WriteLine($"Ending balance is {account3.AccountBalance:c}");

                account4.Credit(3499);
                account4.Debit(100);
                Console.WriteLine($"Ending balance is {account4.AccountBalance:c}");
                Console.WriteLine();

                //array to hold account references 
               Account[] accounts = new Account[6];
                accounts[0] = new SavingsAccount(12000m, 0.34m);
                accounts[1] = new CheckingAccount(7653.34m, 19);
                accounts[2] = new CheckingAccount(34933.51m, 97.23m);
                accounts[3] = new SavingsAccount(2345, 0.16m);
                accounts[4] = new CheckingAccount(2345, 23);
                accounts[5] = new SavingsAccount(9923, 0.76m);

                int answer;

                for (int i = 0; i < accounts.Length; ++i)
                {
                    //loop and check whether the user inputed a negative amount
                    do
                    {
                        Console.WriteLine($"How much will you like to withdraw from Account {i + 1}, enter a positive number?");
                        answer = int.Parse(Console.ReadLine());
                    }
                    while (answer < 0);

                    //pass the users inputted amount to method debit
                    accounts[i].Debit(answer);

                    do
                    {
                        Console.WriteLine($"How much will you like to deposit into Account {i + 1}, enter a postive number?");
                        answer = int.Parse(Console.ReadLine());
                    }                   
                    while (answer < 0);

                    //pass the users inputted amount to method credit
                    accounts[i].Credit(answer);

                    //check to see if the accounts type is SavingsAccount
                    if (accounts[i] is SavingsAccount)
                        {
                        //cast the object to SavingsAccount
                        var savings = (SavingsAccount)accounts[i];

                        //calculate the interest earned and pass it to method credit
                        savings.Credit(savings.CalculateInterest());
                        }

                        //oputput the users uodated balance
                        Console.WriteLine($"Here is your updated aaccount balance, {accounts[i].AccountBalance:c}");                
                }
            }
           
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
