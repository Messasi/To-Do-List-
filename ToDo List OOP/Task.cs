using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List_OOP
{
    internal class Task
    {
        public string Name;
        public DateTime Date;
        public string Priority;
        public string Status;

        public Task(string name, DateTime date, string priority, string status) { 
        
            Name = name;
            Date = date;
            Priority = priority;
            Status = status;
        
        }

        // Override the ToString method to print meaningful information
        public override string ToString()
        {
            return $"Date: {Date.ToString("dd/MM/yy")}, Priority: {Priority}, Status: {Status}";
        }




    }
}
