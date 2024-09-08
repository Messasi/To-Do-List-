﻿using System;
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

            //Taking in user input
            Console.WriteLine("\nEnter task due date: ");
            DateTime taskDate = DateTime.Parse(Console.ReadLine());

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

        //Edit your task 
        static void EditTask()
        {
            Console.Clear();

            //Search for task 
            Console.WriteLine("\nEnter the name of the task you want to edit");
            string Edit_TaskName = Console.ReadLine();

            //If statement print 
            while (!TaskDict.ContainsKey(Edit_TaskName))
            {
                Console.WriteLine("\nTask Name enterd wrong, Please enter again ");
                Edit_TaskName = Console.ReadLine();
            }

            Console.WriteLine($"\nSelected {Edit_TaskName}");

            Console.WriteLine("\nChoose an option from the list to edit from the task: \n1.Task name\n2.Task Due date\n3.Task Priority\n4.Task Status");
            int edit_Tasknum = Convert.ToInt32(Console.ReadLine());
        }





        /*for user choice
        if (edit_Tasknum == 1)
        {

        }
        else if (edit_Tasknum == 2)
        {
            Console.WriteLine("Enter the new due date for your task");
            string edited_taskName = Console.ReadLine();

            Task[1] = edited_taskName;
        }
        else if (edit_Tasknum == 3) 
        { 
        } 
        else if (edit_Tasknum == 4) 
        { 
        }
        */

        static void MainMenuDirectory()
        {
            Console.WriteLine("1.Create Task\n2.Edit Task\n3.Delete Task\n4.Display all tasks\n\nEnter a number from the menu above");

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

                    Console.WriteLine("Press enter to return to main menu....");
                    Console.ReadKey();

                    ReturnToMenu();
                }
                else if (HomePageOption == 2)
                {
                    //Edit Task
                    EditTask();
                }
                else if (HomePageOption == 3)
                {
                    //Delete all tasks
                }
                else if (HomePageOption == 4)
                {
                    //Display all tasks
                    DisplayTasks();
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
