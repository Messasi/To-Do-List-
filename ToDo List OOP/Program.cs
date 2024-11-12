using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDo_List_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Leon's To-Do List");
            
            //Directing the user in the menu 
            MainMenuDirectory();
        }

        //Create a dictionary to store the Task object
        static Dictionary<string, List<Task>> TaskDict = new Dictionary<string, List<Task>>();
        
        //Create a task 
        static async void CreateTask(string Dictkey)
        {

            // Validate and get task due date
            DateTime taskDate;
            while (true)
            {
                Console.WriteLine("\nEnter task due date (DD/MM/YY): ");
                if (DateTime.TryParse(Console.ReadLine(), out taskDate))
                {
                    break;
                }
                Console.WriteLine("Invalid date. Please enter a valid  date.");
                Thread.Sleep(2000);
                Console.Clear();
            }

            string taskPriority;
            bool ispriorityValid = false;
            do
            {
                Console.WriteLine("\nEnter priority (Can only be 'low', 'medium' or 'high') :  ");
                taskPriority = Console.ReadLine();
                if (taskPriority.ToLower() == "low" || taskPriority.ToLower() == "medium" || taskPriority.ToLower() == "high")
                {
                    ispriorityValid = true;
                }
                else
                {
                    Console.WriteLine("Priority Entered invalid, Can only be 'low', 'medium' or 'high' ");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (ispriorityValid == false);


            // Validate status input (make sure it's the correct input)
            bool istaskstatusValid = false;
            string taskStatus;
            do
            {
                Console.WriteLine("\nEnter Status (Can only be 'Not completed', 'In progress' or 'Done') :  ");
                taskStatus = Console.ReadLine();
                if (taskStatus.ToLower() == "not completed" || taskStatus.ToLower() == "in progress" || taskStatus.ToLower() == "done")
                {
                    istaskstatusValid = true;
                }
                else
                {
                    Console.WriteLine("Status Entered invalid, Can only be 'Not completed', 'In progress' or 'Done' ");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (istaskstatusValid == false);


            //Declaring an object
            Task Tasks = new Task(Dictkey, taskDate, taskPriority, taskStatus);

            //if it is not in the dictionary create a new entry
            if (!TaskDict.ContainsKey(Dictkey))
            {
                TaskDict[Dictkey] = new List<Task>();
            }

            //add the student to the entry
            TaskDict[Dictkey].Add(Tasks);

            //Created new task 
            Console.WriteLine($"\nCreated new Task ' {Dictkey} ' successfully!");
        }

        //Display your tasks 
        static async void DisplayTasks()
        {
            Console.Clear();

            //Looping through the dictionary

            if (TaskDict.Count == 0)
            {
                Console.WriteLine("No Tasks to be displayed, returning to main menu....");
                Thread.Sleep(2000);

                Console.Clear();
                MainMenuDirectory();
            }

            Console.WriteLine("Click any key to return to main menu....");

            foreach (var task in TaskDict)
            {
                Console.WriteLine("\n" + task.Key);

                foreach (var item in task.Value)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
            ReturnToMenu();
        }

        static async void editTask()
        {
            //clear the console and then search for the task 
            Console.Clear();

            Console.WriteLine("\nEnter the name of the task you want to edit");
            string Edit_TaskName = Console.ReadLine();

            //If statement print 
            while (!TaskDict.ContainsKey(Edit_TaskName))
            {
                Console.WriteLine("\nTask Name enterd wrong, Please enter again ");
                Edit_TaskName = Console.ReadLine();
            }
            Console.WriteLine($"\nSelected '{Edit_TaskName}'");

            bool editmenunumIsValid = false;
            int editMenuNum = 0;

            do
            {
                Console.WriteLine("\nEnter a number from the menu below: \n\n1.Task name\n2.Task Due date\n3.Task Priority\n4.Task Status\n5.Return to menu");
                editMenuNum = Convert.ToInt32(Console.ReadLine());

                if (editMenuNum == 1 || editMenuNum == 2 || editMenuNum == 3 || editMenuNum == 4 || editMenuNum == 5)
                {
                    editmenunumIsValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (editmenunumIsValid == false);

            switch (editMenuNum)
            {
                case 1: //Task name
                    Console.WriteLine("\nEnter the new name for the task");
                    string newTaskName = Console.ReadLine();

                    //removing the old dictionary and replacing the new dictionary with values
                    var value = TaskDict[Edit_TaskName];

                    TaskDict[newTaskName] = value;
                    TaskDict.Remove(Edit_TaskName);

                    Console.WriteLine("\nTask name successfully\n\nReturning to main menu");

                    Thread.Sleep(2000);
                    ReturnToMenu();
                    break;

                case 2: //task Date
                    Console.WriteLine("\nEnter a new due date for the task (DD/MM/YYYY)");
                    DateTime editdate = DateTime.Parse(Console.ReadLine());

                    var updatedDate = TaskDict[Edit_TaskName].FirstOrDefault();

                    if (updatedDate != null)
                    {
                        // Update the due date
                        updatedDate.Date = editdate;
                        Console.WriteLine("\nDue date updated successfully.\n\nReturning to main menu");
                        Thread.Sleep(2000);
                        ReturnToMenu();
                    }
                    break;

                case 3: // Task Priority 

                    Console.WriteLine("Enter a new priority for the task");
                    string editPriortiy = Console.ReadLine();

                    //Validate Priority
                    bool ispriorityValid = false;
                    do
                    {
                        Console.WriteLine("\nEnter priority (Can only be 'low', 'medium' or 'high') :  ");
                        editPriortiy = Console.ReadLine();
                        if (editPriortiy.ToLower() == "low" || editPriortiy.ToLower() == "medium" || editPriortiy.ToLower() == "high")
                        {
                            ispriorityValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Priority Entered invalid, Can only be 'low', 'medium' or 'high' ");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    } while (ispriorityValid == false);

                    var updatePriority = TaskDict[Edit_TaskName].FirstOrDefault();

                    if(updatePriority != null)
                    {
                        updatePriority.Priority = editPriortiy;
                        Console.WriteLine("\nTask priority updated successfully\n\nReturning to main menu");
                        Thread.Sleep(2000);
                        ReturnToMenu();
                    }
                    break;

                case 4: // Task status
                    // Edit Task Status
                    Console.WriteLine("\nEnter a new status for the task (e.g., Not Started, In Progress, Completed):");
                    string editStatus = Console.ReadLine();


                    //Validate Status
                    bool istaskstatusValid = false;
                    do
                    {
                        Console.WriteLine("\nEnter Status (Can only be 'Not completed', 'In progress' or 'Done') :  ");
                        editStatus = Console.ReadLine();
                        if (editStatus.ToLower() == "not completed" || editStatus.ToLower() == "in progress" || editStatus.ToLower() == "done")
                        {
                            istaskstatusValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Status Entered invalid, Can only be 'Not completed', 'In progress' or 'Done' ");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    } while (istaskstatusValid == false);

                    var updatedStatus = TaskDict[Edit_TaskName].FirstOrDefault(); 

                    if (updatedStatus != null)
                    {
                        // Update the status
                        updatedStatus.Status = editStatus;
                        Console.WriteLine("\nTask status updated successfully.\n\nReturning to main menu");
                        ReturnToMenu();
                    }
                    break;

                case 5:// Back to Menu
                    Console.WriteLine("Entered Return to menu option");
                    Thread.Sleep(2000);
                    ReturnToMenu();
                    break;

                default:
                    ReturnToMenu();
                    break;
            }
        }

        static void deleteTask()
        {
            //get the name of the task to delete 
            Console.Clear();

            Console.WriteLine("\nEnter the name of the task you want to edit");
            string delete_TaskName = Console.ReadLine();

            //If statement print 
            while (!TaskDict.ContainsKey(delete_TaskName))
            {
                Console.WriteLine("\nTask Name entered wrong, Please enter again ");
                delete_TaskName = Console.ReadLine();
            }

            //if it is in the list display it and give a y and no option
            Console.WriteLine($"\nDelete Task '{delete_TaskName}'\nEnter Confirm/Cancel\n");
            string userdeletechoice = Console.ReadLine();

            if (userdeletechoice.ToUpper() == "CONFIRM")
            {
                TaskDict.Remove(delete_TaskName);
                Console.WriteLine($"\nTask '{delete_TaskName}' deleted successfully ");
            }
            else {

                Console.WriteLine("\nTask not deleted");
            }

            Console.WriteLine("\nPress enter to return to main menu....");
            Console.ReadKey();

            ReturnToMenu();
        }

        //To direct direction in the main menu 
        static void MainMenuDirectory()
        {
            Console.WriteLine("1.Create Task\n2.Edit Task\n3.Delete Task\n4.Display all tasks\n5.Quit\n\nEnter a number from the menu above");

            //taking users choice
            int HomePageOption = Convert.ToInt32(Console.ReadLine());




            if (HomePageOption == 1)
            {


                // Clear console
                Console.Clear();

                // Loop to get the valid number of tasks to create
                int taskUserAmount = 0;

                while (true)
                {
                    Console.WriteLine("How many tasks do you want to create (1-4)?");

                    if (int.TryParse(Console.ReadLine(), out taskUserAmount) && taskUserAmount > 0 && taskUserAmount <= 4)
                    {
                        break; // valid input, break the loop
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number between 1 and 4.");
                    }
                }

                // Loop for creating the specified number of tasks
                for (int i = 0; i < taskUserAmount; i++)
                {
                    string taskName;
                    while (true)
                    {
                        Console.WriteLine($"\nEnter Task Name for Task {i + 1}:");
                        taskName = Console.ReadLine();

                        if (!TaskDict.ContainsKey(taskName))
                        {
                            break; // valid task name, break the loop
                        }
                        else
                        {
                            Console.WriteLine("Task name already exists, please enter a new task name.");
                        }
                    }

                    // Create the task with the valid name
                    CreateTask(taskName);
                }


                Console.WriteLine("Press enter to return to main menu....");
                Console.ReadKey();

                ReturnToMenu();
            }
            else if (HomePageOption == 2)
            {
                //Edit Task
                editTask();
            }
            else if (HomePageOption == 3)
            {
                deleteTask();
            }
            else if (HomePageOption == 4)
            {
                //Display all tasks
                DisplayTasks();
            }
            else if (HomePageOption == 5) 
            { 
                Environment.Exit(0);
            }

            Console.ReadKey();         
        }

        static void ReturnToMenu()
        {
            Console.Clear();
            Console.WriteLine("Loading Menu...");
            Thread.Sleep(2000);
            Console.Clear();
            MainMenuDirectory();
        }
        
    }
}   
