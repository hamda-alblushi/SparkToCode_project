// first line of coding,hello hamda
Console.WriteLine("Hello To Spark Code!");

// second line of coding,ask user to enter his full information
Console.WriteLine("Enter your full name: ");
string fullname = Console.ReadLine();

Console.WriteLine("Enter your age: ");
int age = int.Parse(Console.ReadLine());

Console.WriteLine("Enter your phone number: ");
string phoneNumber = Console.ReadLine();

Console.WriteLine("Enter your email address: ");
string email = Console.ReadLine();

 Console.WriteLine("Enter your password: ");
float password = float.Parse ( Console.ReadLine());

Console.WriteLine("Thank you for providing your information!");


// third line of coding,display the user's information
Console.WriteLine("User Information: ");
Console.WriteLine("Full name: " + fullname);
Console.WriteLine("Age: " + age);
Console.WriteLine("Phone number: " + phoneNumber);
Console.WriteLine("Email address: " + email);
Console.WriteLine("Password: " + password);

// fourth line of coding,Operartors
Console.WriteLine("Enter first number: ");
float num1=float.Parse(Console.ReadLine());
Console.WriteLine("Enter second number: ");
float num2 = float.Parse(Console.ReadLine());

Console.WriteLine("Addition: " + (num1 + num2));
Console.WriteLine("Subtraction: " + (num1 - num2));
Console.WriteLine("Multiplication: " + (num1 * num2));
Console.WriteLine("Division: " + (num1 / num2));
Console.WriteLine("Remainder: " + (num1 % num2));

bool result = num1 < num2;
Console.WriteLine("Is First number smaller than Second number? " + result);


// fifth line of coding,Conditional Statements
Console.WriteLine("Enter your Degree: ");
float degree = float.Parse(Console.ReadLine());
if(degree <49)
{
    Console.WriteLine("You are failed");
}
else if (degree >= 50 && degree <= 59)
{
    Console.WriteLine("You are passed with C grade");
}
else if (degree >= 60 && degree <= 69)
{
    Console.WriteLine("You are passed with B grade");
}
else if (degree >= 70 && degree <= 79)
{
    Console.WriteLine("You are passed with A grade");
}
else if (degree >= 80 && degree <= 100)
{
    Console.WriteLine("You are passed with A+ grade");
}
else
{
    Console.WriteLine("Invalid Degree");
}


// sixth line of coding,Switch Case
Console.WriteLine(" Welcome to mean menu: ");
Console.WriteLine("1. Deposite");
Console.WriteLine("2. Withdraw");
Console.WriteLine("3. Balance Enquiry");

Console.WriteLine("Enter your choice: ");
int choice = int.Parse(Console.ReadLine());

switch(choice)
{
    case 1:
        Console.WriteLine("You have selected Deposite");
        break;
    case 2:
        Console.WriteLine("You have selected Withdraw");
        break;
    case 3:
        Console.WriteLine("You have selected Balance Enquiry");
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}








