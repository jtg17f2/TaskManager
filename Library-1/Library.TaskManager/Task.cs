using System;
using System.Collections.Generic;

namespace Library.TaskManager
{
    public class Task
    {
        public string name;
        public string description;
        public string deadline;
        public bool completed;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                
                name = value;
            }
        }
        public Task()
        {
            name = "";
            description = "";
            deadline = "";
            completed = false;
        }
      
        //public task createtask()
        //{
        //    task t1 = new task();
        //    console.writeline("please enter the name of the task.");
        //    t1.name = console.readline();
        //    console.writeline("please enter the description of the task.");
        //    t1.description = console.readline();
        //    console.writeline("please enter the deadline of the task.");
        //    t1.deadline = console.readline();
        //    console.writeline("please enter the name of the task.");
        //    t1.completed = false;
        //    return t1;

        //}
    }
}
