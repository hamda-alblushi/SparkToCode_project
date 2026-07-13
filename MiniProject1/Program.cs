namespace MiniProject1
{
    internal class Program
    {

        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();


        static void Main(string[] args)
        {

            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("\n===== Welcome to Spark Bank =====");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer Amount");
                Console.WriteLine("6. List All Account ");
                Console.WriteLine("7. close Account ");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue; // skip the rest of this loop pass, show the menu again
                }
                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        ListAllAccounts();
                        break;
                    case 7:
                        CloseAccount();
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;
                }
            }
        }
        // ===================== SERVICE FUNCTIONS =====================
        // Each function owns ONE service end-to-end: it asks the user for
        // whatever it needs, validates it, updates the shared lists, and
        // prints the outcome. Main never reads input or prints results
        // for these services - it only shows the menu and calls them.
        static void AddAccount()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            if (accountNumbers.Contains(accountNumber))
            {
                Console.WriteLine("Account number already exists.");
                return;
            }

            Console.Write("Enter initial deposit: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            if (balance < 0)
            {
                Console.WriteLine("Initial deposit cannot be negative.");
                return;
            }

            customerNames.Add(name);
            accountNumbers.Add(accountNumber);
            balances.Add(balance);

            Console.WriteLine("Account created successfully!");
            Console.WriteLine("Customer Name: " + name);
            Console.WriteLine("Account Number: " + accountNumber);
            Console.WriteLine("Balance: " + balance);
        }
        static void DepositMoney()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accountNumber);

            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter deposit amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }

            balances[index] += amount;

            Console.WriteLine("Deposit successful.");
            Console.WriteLine("Updated Balance: " + balances[index]);
        }
        static void WithdrawMoney()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accountNumber);

            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter withdrawal amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return;
            }

            if (amount > balances[index])
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            balances[index] -= amount;

            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine("Updated Balance: " + balances[index]);
        }
        static void ShowBalance()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accountNumber);

            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine("\n===== Account Details =====");
            Console.WriteLine("Customer Name : " + customerNames[index]);
            Console.WriteLine("Account Number: " + accountNumbers[index]);
            Console.WriteLine("Balance       : " + balances[index]);
        }
        static void TransferAmount()
        {
            Console.Write("Enter sender account number: ");
            string senderAccount = Console.ReadLine();

            int senderIndex = accountNumbers.IndexOf(senderAccount);

            if (senderIndex == -1)
            {
                Console.WriteLine("Sender account not found.");
                return;
            }


            Console.Write("Enter receiver account number: ");
            string receiverAccount = Console.ReadLine();

            int receiverIndex = accountNumbers.IndexOf(receiverAccount);

            if (receiverIndex == -1)
            {
                Console.WriteLine("Receiver account not found.");
                return;
            }


            if (senderIndex == receiverIndex)
            {
                Console.WriteLine("Cannot transfer money to the same account.");
                return;
            }


            Console.Write("Enter transfer amount: ");

            double amount;

            try
            {
                amount = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid amount.");
                return;
            }


            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be greater than zero.");
                return;
            }


            if (amount > balances[senderIndex])
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }


            balances[senderIndex] -= amount;
            balances[receiverIndex] += amount;


            Console.WriteLine("Transfer successful!");

            Console.WriteLine("Sender New Balance: " + balances[senderIndex]);
            Console.WriteLine("Receiver New Balance: " + balances[receiverIndex]);
        }


        static void ListAllAccounts()
        {
            if (accountNumbers.Count == 0)
            {
                Console.WriteLine("No accounts available.");
                return;
            }


            Console.WriteLine("\n===== All Accounts =====");


            for (int i = 0; i < accountNumbers.Count; i++)
            {
                Console.WriteLine("Customer Name: " + customerNames[i]);
                Console.WriteLine("Account Number: " + accountNumbers[i]);
                Console.WriteLine("Balance: " + balances[i]);
                Console.WriteLine("------------------------");
            }
        }


        static void CloseAccount()
        {
            Console.Write("Enter account number to close: ");

            string accountNumber = Console.ReadLine();


            int index = accountNumbers.IndexOf(accountNumber);


            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }


            customerNames.RemoveAt(index);
            accountNumbers.RemoveAt(index);
            balances.RemoveAt(index);


            Console.WriteLine("Account closed successfully.");
        }
         







    }
}
