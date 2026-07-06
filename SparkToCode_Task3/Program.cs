namespace SparkToCode_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //====================================================
            // Task 1 - Calculate the Absolute Difference
            //====================================================
            Console.WriteLine("Enter the first Number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second Number: ");
            double num2 = double.Parse(Console.ReadLine());

            double diffrence = Math.Abs(num1 - num2);

            Console.WriteLine("The positive difference is: " + diffrence);

            //====================================================
            // Task 2 - Calculate Square and Square Root
            //====================================================
            Console.WriteLine("Enter number:");

            double number = Convert.ToDouble(Console.ReadLine());

            double root = Math.Sqrt(number);
            double squared = Math.Pow(number, 2);

            Console.WriteLine(" the square is: " + squared);
            Console.WriteLine(" the square root is: " + root);

            //====================================================
            // Task 3 - String Manipulation
            //====================================================
            Console.Write("Enter your full name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Uppercase: " + name.ToUpper());
            Console.WriteLine("Lowercase: " + name.ToLower());
            Console.WriteLine("Characters: " + name.Length);

            //====================================================
            // Task 4 - Calculate Subscription End Date
            //====================================================

            Console.Write("Enter free trial days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            DateTime today = DateTime.Today;
            DateTime endDate = today.AddDays(days);

            Console.WriteLine("Trial End Date: " + endDate.ToString("yyyy-MM-dd"));

            //====================================================
            // Task 5 - Determine Pass/Fail Status
            //====================================================
            Console.Write("Enter your exam score: ");
            double score = Convert.ToDouble(Console.ReadLine());

            double rounded = Math.Round(score);

            Console.WriteLine("Rounded Score = " + rounded);

            if (rounded >= 60)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            //====================================================
            // Task 6 - Check Password Strength
            //====================================================
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (password.Length >= 8 && !password.ToLower().Contains("password"))
            {
                Console.WriteLine("Strong Password");
            }
            else
            {
                Console.WriteLine("Weak Password");

                if (password.Length < 8)
                    Console.WriteLine("Reason: Less than 8 characters");

                if (password.ToLower().Contains("password"))
                    Console.WriteLine("Reason: Contains the word 'password'");
            }



            //====================================================
            // Task 7 - Compare Names
            //====================================================
            Console.Write("Enter first name: ");
            string name1 = Console.ReadLine();

            Console.Write("Enter second name: ");
            string name2 = Console.ReadLine();

            name1 = name1.Trim().ToUpper();
            name2 = name2.Trim().ToUpper();

            if (name1 == name2)
            {
                Console.WriteLine("Match");
            }
            else
            {
                Console.WriteLine("No Match");
            }


            //====================================================
            // Task 8 - Check Membership Status
            //====================================================
            try
            {
                Console.Write("Enter membership start date (yyyy-MM-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter valid membership days: ");
                int days2 = Convert.ToInt32(Console.ReadLine());

                DateTime expiry = startDate.AddDays(days2);

                Console.WriteLine("Expiry Date: " + expiry.ToString("yyyy-MM-dd"));

                if (expiry >= DateTime.Today)
                {
                    Console.WriteLine("Active");
                }
                else
                {
                    Console.WriteLine("Expired");
                }
            }
            catch
            {
                Console.WriteLine("Invalid Date");
            }


            //====================================================
            // Task 9 - Round Decimal Numbers
            //====================================================
            Console.Write("Enter decimal number: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nearest = " + Math.Round(number2));
            Console.WriteLine("Round Up = " + Math.Ceiling(number2));
            Console.WriteLine("Round Down = " + Math.Floor(number2));



            //====================================================
            // Task 10 - Find Word in Sentence
            //====================================================
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();

            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            if (sentence.Contains(word))
            {
                Console.WriteLine("First Position = " + sentence.IndexOf(word));
                Console.WriteLine("Last Position = " + sentence.LastIndexOf(word));
            }
            else
            {
                Console.WriteLine("Word not found");
            }


            //====================================================
            // Task 11 - Generate and Verify OTP
            //====================================================
            Random random = new Random();

            int otp = random.Next(1000, 10000);

            Console.WriteLine("OTP = " + otp);

            int attempts = 3;

            while (attempts > 0)
            {
                try
                {
                    Console.Write("Enter OTP: ");
                    int userOtp = Convert.ToInt32(Console.ReadLine());

                    if (userOtp == otp)
                    {
                        Console.WriteLine("Verified");
                        break;
                    }
                    else
                    {
                        attempts--;

                        if (attempts == 0)
                            Console.WriteLine("Verification Failed");
                        else
                            Console.WriteLine("Wrong OTP. Attempts left: " + attempts);
                    }
                }
                catch
                {
                    attempts--;

                    if (attempts == 0)
                        Console.WriteLine("Verification Failed");
                    else
                        Console.WriteLine("Invalid Input");
                }



                //====================================================
                // Task 12 - Calculate Age
                //====================================================
                try
                {
                    Console.Write("Enter your birth date (yyyy-MM-dd): ");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());

                    int age = DateTime.Today.Year - birthDate.Year;

                    if (DateTime.Today < birthDate.AddYears(age))
                    {
                        age--;
                    }

                    Console.WriteLine("Age = " + age);
                    Console.WriteLine("Born on = " + birthDate.DayOfWeek);
                }
                catch
                {
                    Console.WriteLine("Invalid Date");
                }

                //the end of the program
            }
        }
    }
}
