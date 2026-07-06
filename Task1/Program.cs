namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    ///Task1
        //    Console.WriteLine("Personal Information Card");
        //    Console.WriteLine("Enter your Full Name: ");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Enter your Age: ");
        //    int age = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Enter your Height: ");
        //    double height = double.Parse(Console.ReadLine());
        //    Console.WriteLine("Are you Student? (yes/no): ");
        //    bool isStudent = Console.ReadLine().ToLower() == "yes";

        //    Console.WriteLine("Personal Information:");
        //    Console.WriteLine("Name: " + name);
        //    Console.WriteLine("Age: " + age);
        //    Console.WriteLine("Height: " + height);
        //    Console.WriteLine("Student: " + isStudent);


        //    ///Task2
        //    Console.WriteLine("Enter the length of the rectangle: ");
        //    float length = float.Parse(Console.ReadLine());
        //    Console.WriteLine("Enter the width of the rectangle: ");
        //    float width = float.Parse(Console.ReadLine());
        //    float area = length * width;
        //    Console.WriteLine("Area of the rectangle: " + area);
        //    float perimeter = 2 * (length + width);
        //    Console.WriteLine("Perimeter of the rectangle: " + perimeter);

        //    //Task3
        //    Console.WriteLine("Enter number to check if it is even or odd: ");
        //    int number = int.Parse(Console.ReadLine());
        //    if (number % 2 == 0)
        //    {
        //        Console.WriteLine(number + " is an even number.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(number + " is an odd number.");
        //    }

        //    //Task4
        //    Console.WriteLine("Enter your Age: ");
        //    int age2=int.Parse(Console.ReadLine());
        //    Console.WriteLine("Do you Have National ID? (yes/no): ");
        //    bool hasNationalID = Console.ReadLine().ToLower() == "yes";
        //    if (age2>= 18 && hasNationalID)
        //    { Console.WriteLine("you are eligible to vote."); }
        //    else
        //    { Console.WriteLine("You are not eligible to vote."); }

        //    // Task5
        //    Console.WriteLine("Enter your  Character Grade: ");
        //    char grade = char.Parse(Console.ReadLine());
        //    switch (grade)
        //    {
        //        case 'A':
        //            Console.WriteLine("Excellent!");
        //            break;
        //        case 'B':
        //            Console.WriteLine("Very Good!");
        //            break;
        //        case 'C':
        //            Console.WriteLine("Good.");
        //            break;
        //        case 'D':
        //            Console.WriteLine("Pass");
        //            break;
        //        case 'F':
        //            Console.WriteLine("Failed.");
        //            break;
        //        default:
        //            Console.WriteLine("Invalid grade.");
        //            break;
        //    }
        //// Task6
        //Console.WriteLine("Enter the Temperature : ");
        //float temperature = float.Parse(Console.ReadLine());
        //float fahrenheit = (temperature * 9 / 5) + 32;
        //Console.WriteLine("Temperature in Fahrenheit: " + fahrenheit);
        //if(temperature<10)
        //    {
        //        Console.WriteLine("It's cold.");
        //    }
        //else if ((temperature>=10 && temperature<=30))
        //    {
        //     Console.WriteLine("It's moderate.");
        //    }
        //else
        //    {
        //        Console.WriteLine("It's hot.");
        //}
        //Task7
        Console.WriteLine("Enter your age for Ticket movie : ");
            int age3 = int.Parse(Console.ReadLine());
            if(age3<=0 && age3<=12)
            {  Console.WriteLine("You are a child, ticket price is 2 OMR."); }
            else if (age3 >= 13 && age3 <= 59)
            { Console.WriteLine("You are a teenager, ticket price is 5 OMR."); }
            else if (age3 >= 60)
            { Console.WriteLine("You are a senior citizen, ticket price is 3 OMR."); }

            // Task8
            Console.WriteLine("Enter your bill amount: ");
            float billAmount = float.Parse(Console.ReadLine());
            Console.WriteLine("are you a loyalty member? (yes/no): ");
            bool isLoyalMember = Console.ReadLine().ToLower() == "yes";

            if (isLoyalMember)
            {
                float discount = billAmount * 0.1f; // 10% discount
                Console.WriteLine("You are a loyal customer!");
                Console.WriteLine("Discount: " + discount);
                Console.WriteLine("Total amount after discount: " + (billAmount - discount));
            }
            else
            {
                Console.WriteLine("You are not a loyal customer.");
                Console.WriteLine("Total amount: " + billAmount);
            }

            // Task9
            Console.WriteLine("Enter number of day (1-7): ");
            int day= int.Parse(Console.ReadLine());
            switch (day)
            {
                case 1:
                    Console.WriteLine("sunday");
                    break;
                case 2:
                    Console.WriteLine("Monday");
                    break;
                case 3:
                    Console.WriteLine("Tuesday");
                    break;
                case 4:
                    Console.WriteLine("Wednesday");
                    break;
                case 5:
                    Console.WriteLine("Thursday");
                    break;
                case 6:
                    Console.WriteLine("Friday");
                    break;
                case 7: 
                    Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("Invalid day number.");
                    break;
            }

            // Task10
            Console.WriteLine("Enter two number and any operator (+, -, *, /): ");
            Console.WriteLine("Enter first number: ");
            float num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            float num2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter operator (+, -, *, /): ");
            char op = char.Parse(Console.ReadLine());
            switch(op) {
                case '+':
                    Console.WriteLine("Result: " + (num1 + num2));
                    break;
                case '-':
                    Console.WriteLine("Result: " + (num1 - num2));
                    break;
                case '*':
                    Console.WriteLine("Result: " + (num1 * num2));
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        Console.WriteLine("Result: " + (num1 / num2));
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    break;
            }


            // Task11
            Console.WriteLine("Enter your age: ");
            int age4 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your  Monthly Income: ");
            float income = float.Parse(Console.ReadLine());
            Console.WriteLine(" Did you  have an existing loan (yes/no) : ");
            bool hasExistingLoan = Console.ReadLine().ToLower() == "yes";
            
            if(age4>=21 && age4 <= 60 && income >= 400 && !(hasExistingLoan==true))
            {
                Console.WriteLine("You are eligible for a loan.");
            }
            else
            {
                if(age4< 21 || age4 > 60)
                {
                    Console.WriteLine("You are not eligible for a loan due to age restrictions.");
                }
                else if (income < 400)
                {
                    Console.WriteLine("You are not eligible for a loan due to insufficient income.");
                }
                else if (hasExistingLoan)
                {
                    Console.WriteLine("You are not eligible for a loan due to existing loan.");
                }
            }

            // Task12
            Console.WriteLine("Enter Regoin code: ");
            Console.WriteLine("A: Local");
            Console.WriteLine("B: National");
            Console.WriteLine("C: International");
            string regionCode = Console.ReadLine();
            Console.WriteLine("Enter the package weight (in kg): ");
            float packageWeight = float.Parse(Console.ReadLine());
            double shippingCost = 0;
            double extracharge = 0;
            switch (regionCode)
            {
                case "A":
                    shippingCost = 1.00;
                    if (packageWeight > 10)
                    {
                        extracharge = (packageWeight + 5.00);
                    }
                    else if (packageWeight > 5)
                    {
                        extracharge = (packageWeight + 2.00);
                    }
                    Console.WriteLine("Region A: Local");
                    Console.WriteLine("Shipping Cost: " + shippingCost);
                    Console.WriteLine("Total shipping cost: " + extracharge);
                    break;
                case "B":
                    shippingCost = 1.00;
                    if (packageWeight > 10)
                    {
                        extracharge = (packageWeight + 5.00);
                    }
                    else if (packageWeight > 5)
                    {
                        extracharge = (packageWeight + 2.00);
                    }
                    Console.WriteLine("Region B: National");
                    Console.WriteLine("Shipping Cost: " + shippingCost);
                    Console.WriteLine("Total shipping cost: " + extracharge);
                    break;
                case "C":
                    shippingCost = 1.00;
                    if (packageWeight > 10)
                    {
                        extracharge = (packageWeight + 5.00);
                    }
                    else if (packageWeight > 5)
                    {
                        extracharge = (packageWeight + 2.00);
                    }
                    Console.WriteLine("Region C: International");
                    Console.WriteLine("Shipping Cost: " + shippingCost);
                    Console.WriteLine("Total shipping cost: " + extracharge);
                    break;
                default:
                    Console.WriteLine("Invalid region code.");
                    break;
            }

// End of Main method, class and namespace
    }
}
}

