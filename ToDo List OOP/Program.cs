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
            Dictionary<string, object> dict = new Dictionary<string, object>();

            
            DisplayHomeMenu();
            



            
            Console.ReadKey();
        }

       //Displaying Homepage Menu
        static void DisplayHomeMenu()
        {
            Console.WriteLine("1.Create Task\n2.Edit Task\n3.Delete Task\n 4.Display all tasks\n\nEnter a number from the menu above");
        }
        
        
    }
}   
