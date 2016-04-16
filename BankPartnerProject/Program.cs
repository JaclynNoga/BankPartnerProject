using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankPartnerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client();
            Account account1 = new Account();
            StreamWriter writer = new StreamWriter("AccountSummary.txt");
            bool exit = true;   //used for do while loop
            using (writer)  //opens file stream
            {
                writer.WriteLine($"Name: {client1.ClientName}");
                writer.WriteLine($"Account Number: {client1.AccountNum}");
                writer.WriteLine();
                Console.WriteLine("Welcome to my bank!\n***********************");
                do
                {
                    decimal amount = 0.00M; //used to print out amount withrawn or deposited 

                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    Console.WriteLine("\nMenu\n***********************");
                    Console.WriteLine("1. View Client Information\n2. View Account Balance\n3. Deposit Funds\n4. Withdraw Funds\n5. Exit");
                    int answer = 0;     //initialized here so if try parse doesn't work the switch case will go to default
                    int.TryParse(Console.ReadLine(), out answer);
                    Console.Clear();
                    switch (answer)
                    {
                        //view client info
                        case 1:
                            Console.WriteLine("Name: {0}\nAccount Number: {1}", client1.ClientName, client1.AccountNum);
                            break;
                        //view account balance
                        case 2:
                            Console.WriteLine($"Account Balance: ${account1.AccountBalance}"); ;
                            break;
                        //deposit funds
                        case 3:
                            Console.WriteLine("Enter deposit amount: ");
                            amount += (decimal.Parse(Console.ReadLine()));    //adds the amount that the user wants to deposit to 0.00 so that it is in format $0.00 in the text file
                            account1.Deposit(amount);
                            writer.WriteLine("{0}   +   ${1}     ${2}", account1.Time, amount, account1.AccountBalance);
                            break;
                        //withdraw funds
                        case 4:
                            Console.WriteLine("Enter withdraw amount: ");
                            amount += account1.OverdraftChecker(decimal.Parse(Console.ReadLine()));    //adds amount that user wants to withdraw to 0.00 to format it to $0.00
                            account1.Withdraw(amount);
                            writer.WriteLine("{0}   -   ${1}     ${2}", account1.Time, amount, account1.AccountBalance);
                            break;
                        //exit
                        case 5:
                            Console.WriteLine("Thank you for your patronage.");
                            exit = false;   //exits the loop
                            break;
                        //if tryparse fails
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
                while (exit);
            }   //end of the file stream
        }
    }
}
