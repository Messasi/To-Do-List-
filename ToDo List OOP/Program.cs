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

                //get object info 
                Console.WriteLine("Enter Task Name:\n");
                string taskName = Console.ReadLine();

                Console.WriteLine("Enter due date:");
                string Task_dueDate = Console.ReadLine();

                Console.WriteLine("Enter task priority:  High - neutral - Low");
                string taskPriority = Console.ReadLine();

                Console.WriteLine("Enter the task status: Completed - In progress - Not started");
                string taskStatus = Console.ReadLine();


                Task task = new Task(taskName, Task_dueDate, taskPriority, taskStatus);


               Console.WriteLine(task);

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
            Console.WriteLine("1.Create Task\n2.Edit Task\n3.Delete Task\n 4.Display all tasks\n Enter a number from the menu above");
        }
        
        /*Create a task 
        static Dictionary (Dictionary task)
        {

           


            
            
        }*/
        
    }
}   
