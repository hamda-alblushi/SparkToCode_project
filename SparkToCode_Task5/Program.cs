namespace SparkToCode_Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1:Fix Student grades Array: 

            int[] grades = new int[5];
            grades[0] = 80;
            grades[1] = 90;
            grades[2] = 75;
            grades[3] = 95;
            grades[4] = 85;

            for (int i = 0; i < 5; i++) 
            {

                Console.WriteLine("Enter grade for student : " + (i + 1) + ": ");
                grades[i] = Convert.ToInt32(Console.ReadLine()); 
            }
            Console.WriteLine("Student grades are: ");
            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }
             
            //Task 2: Dynamic To do list:   
            List<int> list = new List<int>();
            Console.WriteLine("Enter the number of tasks you want to add: ");
            int numberOfTasks = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < numberOfTasks; i++)
            {
                Console.WriteLine("Enter task " + (i + 1) + ": ");
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("Your to-do list is: ");
            foreach (int task in list)
            {
                Console.WriteLine(task);
            }

            //Task3:Browsing  History stack:  
            
            Stack<string> history = new Stack<string>();
            
            for (int i = 0;i < history.Count;i++)
            { 
                Console.WriteLine("Enter the URL for page " + (i + 1) + ": ");
                string url = Console.ReadLine();
                history.Push(url);
            }
            string currentPage = history.Peek();
            Console.WriteLine(" you passed the following pages: ");
            Console.WriteLine("Current page: " + currentPage);
            Console.WriteLine("current page: " + history.Pop());

            //Task4: customer service queue: 
             
            Queue<string> customers = new Queue<string>();

            
            Console.Write("Enter first customer name: ");
            customers.Enqueue(Console.ReadLine());

            Console.Write("Enter second customer name: ");
            customers.Enqueue(Console.ReadLine());

            Console.Write("Enter third customer name: ");
            customers.Enqueue(Console.ReadLine());

            
            string servedCustomer = customers.Dequeue();

            Console.WriteLine("Customer served: " + servedCustomer);

            //Task5: لowest, highest, and average grade: 

            int[] grades1 = new int[5];

            
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter grade " + (i + 1) + ": ");
                grades1[i] = int.Parse(Console.ReadLine());
            }

            
            Array.Sort(grades1);

            
            int sum = 0;

            for (int i = 0; i < grades1.Length; i++)
            {
                sum += grades1[i];
            }

            double average = sum / 5.0;

            
            Console.WriteLine("Lowest grade: " + grades1[0]);
            Console.WriteLine("Highest grade: " + grades1[4]);
            Console.WriteLine("Average grade: " + average);


            //Task6:filltered shopping list: 

            List<string> shoppingList = new List<string>();

            while (shoppingList.Count > 0) {
                Console.WriteLine("Enter an item to add to the shopping list (or type 'done' to finish): ");
                string inputItem = Console.ReadLine();
                shoppingList.Add(inputItem);

                if (inputItem.ToLower() == "done")
                {
                    break;
                }
                shoppingList.Add(inputItem);

                Console.WriteLine("Shopping list before removal:");

                foreach (string item in shoppingList)
                {
                    Console.WriteLine(item);
                }

                
                Console.Write("Enter item to remove: ");
                string removeItem = Console.ReadLine();

                shoppingList.Remove(removeItem);

               
                Console.WriteLine("Shopping list after removal:");

                foreach (string item in shoppingList)
                {
                    Console.WriteLine(item);
                }


                //Task7: highest score podium: 

                List<int> scores = new List<int>();

                for (int i = 0; i < 5; i++)
                {
                    Console.Write("Enter score " + (i + 1) + ": ");
                    scores.Add(int.Parse(Console.ReadLine()));
                }

                
                scores.Sort();
                scores.Reverse();

                Console.WriteLine("High Score Podium:");

                Console.WriteLine("1st place: " + scores[0]);
                Console.WriteLine("2nd place: " + scores[1]);
                Console.WriteLine("3rd place: " + scores[2]);

                //Task8:undo last action:
                Stack<string> actions = new Stack<string>();

                
                while (true)
                {
                    Console.Write("Enter action (type stop to finish): ");
                    string action = Console.ReadLine();

                    if (action == "stop")
                    {
                        break;
                    }

                    actions.Push(action);
                }

                Console.WriteLine("Undo actions:");

                string undo1 = actions.Pop();
                Console.WriteLine("Undone: " + undo1);

                string undo2 = actions.Pop();
                Console.WriteLine("Undone: " + undo2);

                
                Console.WriteLine("Remaining actions:");

                foreach (string action in actions)
                {
                    Console.WriteLine(action);
                }



                //Task9:  

                List<int> grades2= new List<int>();

                Console.Write("How many grades do you want to enter? ");
                int count = int.Parse(Console.ReadLine());

                
                for (int i = 0; i < count; i++)
                {
                    Console.Write("Enter grade " + (i + 1) + ": ");
                    grades2.Add(int.Parse(Console.ReadLine()));
                }

                
                double average1= CalculateAverage(grades2);
                int failingGrade = FindFirstFailing(grades2 );

                
                Console.WriteLine("Average: " + average1);

                if (failingGrade == 0)
                {
                    Console.WriteLine("No failing grade found.");
                }
                else
                {
                    Console.WriteLine("First failing grade: " + failingGrade);
                }
            

            static double CalculateAverage(List<int> grades)
            {
                int sum = 0;

                foreach (int grade in grades)
                {
                    sum += grade;
                }

                return (double)sum / grades.Count;
            }

           
            static int FindFirstFailing(List<int> grades)
            {
                return grades.Find(x => x < 60);
            }

                //Task10:
                Queue<string> printQueue = new Queue<string>();

                
                while (true)
                {
                    Console.Write("Enter print job name (type done to finish): ");
                    string job = Console.ReadLine();

                    if (job == "done")
                    {
                        break;
                    }

                    printQueue.Enqueue(job);
                }

                
                Console.WriteLine("Print queue before cancellation:");

                foreach (string job in printQueue)
                {
                    Console.WriteLine(job);
                }

                
                Console.Write("Enter job name to cancel: ");
                string cancelJob = Console.ReadLine();

               
                printQueue = RemoveJob(printQueue, cancelJob);

                
                Console.WriteLine("Print queue after cancellation:");

                foreach (string job in printQueue)
                {
                    Console.WriteLine(job);
                }
            
            static Queue<string> RemoveJob(Queue<string> queue, string jobToRemove)
            {
                Queue<string> newQueue = new Queue<string>();

                while (queue.Count > 0)
                {
                    string currentJob = queue.Dequeue();

                    if (currentJob != jobToRemove)
                    {
                        newQueue.Enqueue(currentJob);
                    }
                }

                return newQueue;
            }


        }



        }
    }
}
