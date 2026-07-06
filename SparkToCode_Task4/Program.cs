namespace SparkToCode_Task4
{
    internal class Program
    {
        //TASK1 : Create a method called PrintWelcome that takes a string parameter called name and prints "Welcome " followed by the name to the console.
        static void PrintWelcome(string name)
        {
            Console.WriteLine("Welcome " + name);
        }

        //TASK2 : Create a method called Square that takes an integer parameter called number and returns the square of that number .
        static int Square(int number)
        {
            return number * number;
        }

        //TASK3: convert celsius to fahrenheit 
        static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        //TASK4:display menu and take user input to perform the selected operation 
        static void DisplayMenu() { 
          Console.WriteLine("select an operation:");
          Console.WriteLine("1-start");
            Console.WriteLine("2-help");
            Console.WriteLine("3-exit");
        }

        //TASK5:Create a method called IsEven that takes an integer parameter called number and returns true if the number is even, and false if the number is odd.
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        //TASK6:  Create a method called CalculateArea that takes two double parameters called length and width and returns the area of a rectangle (length * width).
        static double CalculateArea(double length, double width)
        {
            return length * width;
        }

        static double CalculatePerimeter(double length, double width)
        {
            return 2 * (length + width);
        }

        //TASK7:  Create a method called GetGradeLetter that takes an integer parameter called score and returns a string representing the letter grade based on the following scale:
        static string GetGradeLetter(int score)
        {
            if (score >= 90)
                return "A";

            else if (score >= 80)
                return "B";

            else if (score >= 70)
                return "C";

            else if (score >= 60)
                return "D";

            else
                return "F";
        }

        //TASK8:  Create a method called Countdown that takes an integer parameter called start and prints a countdown from the start value to 1, one number per line.
        static void Countdown(int start)
        {
            for (int i = start; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }

        //TASK9 :  Create a method called Multiply that takes two integer parameters called a and b and returns the product of a and b. Overload this method to also accept two double parameters and return the product as a double. Additionally, overload the method to accept three integer parameters and return the product of all three integers.
        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }

        //TASK10:  Create a method called CalculateArea that takes a single double parameter called side and returns the area of a square (side * side).
        static double CalculateArea(double side)
        {
            return side * side;
        }

        static double CalculateArea2(double length, double width)
        {
            return length * width;
        }

        //TASK11: Function-Based Calculator
        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double MultiplyNumbers(double num1, double num2)
        {
            return num1 * num2;
        }

        static double DivideNumbers(double num1, double num2)
        {
            try
            {
                if (num2 == 0)
                    throw new DivideByZeroException();

                return num1 / num2;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
                return 0;
            }
        }

        //TASK12:Student Report Card Generator
        static double CalculateAverage(double score1, double score2, double score3)
        {
            return (score1 + score2 + score3) / 3;
        }

        static string GetGradeLetter(double average)
        {
            if (average >= 90)
                return "A";
            else if (average >= 80)
                return "B";
            else if (average >= 70)
                return "C";
            else if (average >= 60)
                return "D";
            else
                return "F";
        }

        static void PrintReportCard(string name, double average, string grade)
        {
            Console.WriteLine("\n===== Student Report Card =====");
            Console.WriteLine("Student Name : " + name);
            Console.WriteLine("Average      : " + average);
            Console.WriteLine("Grade        : " + grade);
        }


        static void DisplayResult(string operation, double result)
        {
            Console.WriteLine(operation + " Result = " + result);
        }

        static void Main(string[] args)
        {
            //TASK1 : Call the PrintWelcome method with your name
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            PrintWelcome(name);

            //TASK2 : Call the Square method with a number and print the result
            Console.Write("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = Square(number);

            Console.WriteLine("Square = " + result);

            //TASK3: Call the CelsiusToFahrenheit method with a celsius value and print the result
            Console.Write("Enter temperature in Celsius: ");
            double celsius = Convert.ToDouble(Console.ReadLine());
            double fahrenheit = CelsiusToFahrenheit(celsius);
            Console.WriteLine("Temperature in Fahrenheit = " + fahrenheit);


            //Task4: display menu and take user input to perform the selected operation
            DisplayMenu();
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You selected option: " + choice);

            //TASK5: Call the IsEven method with a number and print whether it is even or odd
            Console.Write("Enter number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            if (IsEven(number2))
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }

            //TASK6: Call the CalculateArea method with length and width and print the area of the rectangle
            Console.Write("Enter length: ");
            double length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter width: ");
            double width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Area of rectangle = " + CalculateArea(length, width));
            Console.WriteLine("Perimeter of rectangle = " + CalculatePerimeter(length, width));

            //TASK7: Call the GetGradeLetter method with a score and print the letter grade
            Console.Write("Enter score: ");

            int score = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Grade = " + GetGradeLetter(score));


            //TASK8: Call the Countdown method with a start value and print the countdown
            Console.Write("Enter start number: ");

            int start = Convert.ToInt32(Console.ReadLine());

            Countdown(start);

            //TASK9: Call the Multiply method with different parameter types and print the results
            Console.WriteLine(Multiply(5, 4));

            Console.WriteLine(Multiply(2.5, 4.5));

            Console.WriteLine(Multiply(2, 3, 4));

            //TASK10: Call the CalculateArea method with a side value and print the area of the square
            Console.WriteLine("Choose Shape:");
            Console.WriteLine("1. Square");
            Console.WriteLine("2. Rectangle");

            int choice1 = Convert.ToInt32(Console.ReadLine());

            if (choice1 == 1)
            {
                Console.Write("Enter side: ");
                double side = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Area = " + CalculateArea(side));
            }
            else if (choice1 == 2)
            {
                Console.Write("Enter length: ");
                double length1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter width: ");
                double width1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Area = " + CalculateArea2(length1, width1));
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }


            //TASK11:Function-Based Calculator
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nCalculator Menu");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");

                Console.Write("Choose: ");
                int choice2 = Convert.ToInt32(Console.ReadLine());

                if (choice2 == 5)
                {
                    exit = true;
                    break;
                }

                Console.Write("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                switch (choice2)
                {
                    case 1:
                        DisplayResult("Addition", Add(num1, num2));
                        break;

                    case 2:
                        DisplayResult("Subtraction", Subtract(num1, num2));
                        break;

                    case 3:
                        DisplayResult("Multiplication", MultiplyNumbers(num1, num2));
                        break;

                    case 4:
                        DisplayResult("Division", DivideNumbers(num1, num2));
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                //TASK12 :Student Report Card Generator
                Console.Write("Enter student name: ");
                string name2 = Console.ReadLine();

                Console.Write("Enter score 1: ");
                double score1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter score 2: ");
                double score2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter score 3: ");
                double score3 = Convert.ToDouble(Console.ReadLine());

                double average = CalculateAverage(score1, score2, score3);

                string grade = GetGradeLetter(average);

                PrintReportCard(name2, average, grade);




            }














        }
    }
}
