namespace OOP_test
{

    public class BankAccount
    {
        //properties
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public double balance { get; set; }


    }
    


    public class student
    {

    }

    public class product
    {

    }


    public class Program
    {
        static void Main(string[] args)
        {
            //variable declaration
            int grade = 90; //declare a variable of type int and assign it a value of 90
            string name = "hamda"; //declare a variable of type string and assign it a value of "hamda"
            string adress = "muscat"; //declare a variable of type string and assign it a value of "muscat"

            console.writeline("student name: " + name);
            console.writeline("student grade: " + grade);
            console.writeline("student adress: " + adress);


            //create an object of student class
            student s1= new student();
            s1 .Name= "hamda"; //assign the value of name variable to the Name property of s1 object
            s1.Grade = 90; //assign the value of grade variable to the Grade property of s1 object
            s1.Adress = "muscat"; //assign the value of adress variable to the Adress property of s1 object
            //s1.email ="hamda@gmail.com"; //this line will give an error because email is a private field and cannot be accessed outside the class

            console.writeline("student name: " + s1.Name);
            console.writeline("student grade: " + s1.Grade) 
            console.writeline("student adress: " + s1.Adress);


            student s2= new student();
            s2 .Name= "ali"; 
            s2.Grade = 85; 
            s2.Adress = "sultan qaboos";
            s2.Register("hamda@gmail.com")

            // access modifires (public, private, protected, internal) are used to control the access of class members (fields, properties, methods) from outside the class. In this case, email and age are private fields and cannot be accessed outside the class.

            BankAccount b1= new BankAccount();
            b1.AccountNumber = 12345;
            b1.AccountHolder = "hamda";
            b1.balance= 500;
            

            double result = b1.balance; //assign the value of balance property of b1 object to result variable

            BankAccount b2 = new BankAccount();
            b2.AccountNumber = 67890;
            b2.AccountHolder = "ali";
            b2.balance= 500;

            double result2 = b2.checkBalance(); 

        }
    }
