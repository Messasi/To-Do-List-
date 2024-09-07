using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            //Creating dictionary
           // Dictionary<string, List<Task>> dict = new Dictionary<string, List<Task>>();

            
            DisplayHomeMenu();
            //taking users choice
            int HomePageOption = Convert.ToInt32(Console.ReadLine());

            if (HomePageOption == 1)
            {
                //clear console
                Console.Clear();

                //Create a loop for amount of task to create
                Console.WriteLine("How many tasks do you want to create?");
                int taskUserAmount = Convert.ToInt32(Console.ReadLine());

    

                for (int i = 0; i < taskUserAmount; i++)
                
                {

                    //get object info 
                    Console.WriteLine("\nEnter Task Name:");
                    string taskName = Console.ReadLine();

                    //Declaring taskname as dictionary key 
                    string DictKey = taskName;

                    CreateTask(DictKey);
                }



                DisplayTask();
                //Create task function
            }
            else if (HomePageOption == 2)
            {
                //Edit Task
            }
            else if (HomePageOption == 3)
            {
                //Delete all tasks
            }
            else if (HomePageOption == 4) 
            { 
                //Display all tasks
            }


            Console.ReadKey();
        }

       //Displaying Homepage Menu
        static void DisplayHomeMenu()
        {
            Console.WriteLine("1.Create Task\n2.Edit Task\n3.Delete Task\n4.Display all tasks\n\nEnter a number from the menu above");
        }

        //Create a dict
        static Dictionary<string, List<Task>> TaskDict = new Dictionary<string, List<Task>>();
        
        //Create a task 
        static void CreateTask(string Dictkey)
        {

            //Taking in user input
            Console.WriteLine("\nEnter task due date: ");
            string taskDate = Console.ReadLine();

            Console.WriteLine("\nEnter priority: ");
            string taskPriority = Console.ReadLine();

            Console.WriteLine("\nEnter Status: ");
            string taskStatus = Console.ReadLine();

            //Declaring an object
            Task Tasks = new Task(Dictkey, taskDate, taskPriority, taskStatus);

            //if it is not in the dictionary create a new entry
            if (!TaskDict.ContainsKey(Dictkey))
            {
                TaskDict[Dictkey] = new List<Task>();
            }


            //add the student to the entry
            TaskDict[Dictkey].Add(Tasks);


            Console.WriteLine($"\nCreated new Task {Dictkey} successfully!");
            


        }

        static void DisplayTask()
        {
            
            foreach (var task in TaskDict)
            {
                Console.WriteLine("\n\n" + task.Key);

                foreach (var item in task.Value)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}   
