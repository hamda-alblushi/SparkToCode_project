namespace OOP_test
{

    public class BankAccount
    {
        // Properties
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public double balance { get; set; }

        //methods

        public void Deposit(double amount)
        {
            balance += amount;
            SendEmail()
        }

        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                SendEmail()
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        public double CheckBalance()
        {
            PrintInformation();
            return Balance;
        }

        private void PrintInformation()
        {
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Holder Name: " + HolderName);
            Console.WriteLine("Balance: " + Balance);
        }


        private void SendEmail()
        {
            Console.WriteLine("Email notification sent.");
        }
    }

    //--------------------------------------------------------------------

        public class student
    {
       public string Name { get; set; }

        public int Grade { get; set; }

        public string Adress { get; set; }

        private string email { get; set; } 

        private int age { get; set; }

        //methods
        public void Register(string Email)
        {
            email = Email;
            SendEmail();
        }

        private void SendEmail()
        {
            Console.WriteLine("Email notification sent.");
        } 

    }

    //--------------------------------------------------------------------

    public class product
    {
        public string productName { get; set; }
        public double prices { get; set; }
        public int stockQuantities { get; set; }

        //mathods

        public void Sell(int quantity) 
        {
            if (quantity <= StockQuantity)
            {
                StockQuantity -= quantity;
            }
            else
            {
                Console.WriteLine("Not enough stock.");
            }

            LogTransaction();
        }

        public void Restock(int quantity)
        {
            StockQuantity += quantity;
            LogTransaction();
        }

        public double GetInventoryValue()
        {
            PrintDetails();
            return Price * StockQuantity;
        }

        private void PrintDetails()
        {
            Console.WriteLine("Product: " + ProductName);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Stock: " + StockQuantity);
        }

        private void LogTransaction()
        {
            Console.WriteLine("Transaction logged.");
        }



    }

    //--------------------------------------------------------------------

    public class Program
    {

        /// six individuals are created using the student class and their properties are set using the object initializer syntax. .

        static BankAccount account1 = new BankAccount { AccountNumber = 1, HolderName = "Hamda", balance = 500 };
        static BankAccount account2 = new BankAccount { AccountNumber = 2, HolderName = "Fatma", balance = 400 };

        static student s1 = new student { Name = "Noora", Grade = 90, Adress = "muscat" };
        static student s2 = new student { Name = "Meera", Grade = 98, Adress = "sohar" };

        static product p1 = new product { productName = "Laptop", prices = 1000, stockQuantities = 10 };
        static product p2 = new product { productName = "Phone", prices = 500, stockQuantities = 20 };





        static void Main(string[] args)
        {
            bool exitApp = false;

            while (exitApp == false)
            {
                Console.WriteLine("\n===== OOP Part 1 - Bank / Student / Product Manager =====");
                Console.WriteLine(" 1. View Account Details");
                Console.WriteLine(" 2. Update Student Address");
                Console.WriteLine(" 3. Make a Deposit");
                Console.WriteLine(" 4. Make a Withdrawal");
                Console.WriteLine(" 5. View Product Details");
                Console.WriteLine(" 6. Register a Student");
                Console.WriteLine(" 7. Compare Two Account Balances");
                Console.WriteLine(" 8. Restock Product & Stock Level Check");
                Console.WriteLine(" 9. Transfer Between Accounts");
                Console.WriteLine("10. Update Student Grade (Validated)");
                Console.WriteLine("11. Student Report Card");
                Console.WriteLine("12. Account Health Status");
                Console.WriteLine("13. Bulk Sale With Revenue Calculation");
                Console.WriteLine("14. Scholarship Eligibility Check");
                Console.WriteLine("15. Full Balance Top-Up Flow");
                Console.WriteLine("16. Quick Account Opening (Parameterized Constructor)");
                Console.WriteLine("17. Total Students Counter (Static Field & Method)");
                Console.WriteLine("18. Overdrawn Account Check (Read-Only Property)");
                Console.WriteLine("19. Set Student Security PIN (Write-Only Property)");
                Console.WriteLine("20. Exit");
                Console.Write("Choose an option: ");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
                    continue;
                }

                switch (choice)
                {
                    case 1: ViewAccountDetails(); break;
                    case 2: UpdateStudentAddress(); break;
                    case 3: MakeDeposit(); break;
                    case 4: MakeWithdrawal(); break;
                    case 5: ViewProductDetails(); break;
                    case 6: RegisterStudent(); break;
                    case 7: CompareAccountBalances(); break;
                    case 8: RestockProduct(); break;
                    case 9: TransferBetweenAccounts(); break;
                    case 10: UpdateStudentGrade(); break;
                    case 11: StudentReportCard(); break;
                    case 12: AccountHealthStatus(); break;
                    case 13: BulkSaleWithRevenue(); break;
                    case 14: ScholarshipEligibilityCheck(); break;
                    case 15: FullBalanceTopUpFlow(); break;
                    case 16: QuickAccountOpening(); break;
                    case 17: TotalStudentsCounter(); break;
                    case 18: OverdrawnAccountCheck(); break;
                    case 19: SetStudentSecurityPin(); break;
                    case 20:
                        exitApp = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 20.");
                        break;
                }
            }


        }
    }
