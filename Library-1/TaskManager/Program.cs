// Name: Jack Garthwaite
// Assignment: Assignment 1
// Date: 5/26/2021
// First phase of task manager app

using Library.TaskManager;
using System;
using System.Collections.Generic;

namespace TaskManager
{
    class Program
    {
        //function to print list of incompleted tasks
        static void printListInc(List<Task> taskList)
        {
            for (int j = 0; j < taskList.Count; j++)
            {
                if (taskList[j].completed == false)
                {
                    Console.WriteLine("Task {0}\n Name: {1}\n Description: {2}\n Deadline: {3} ", j + 1, taskList[j].name, taskList[j].description, taskList[j].deadline);
                    Console.WriteLine($"Status: {(taskList[j].completed == false ? "Incomplete" : "Complete")}.\n");

                }
            }
        }
        //function to print list of all tasks
        static void printList(List<Task> taskList)
        {
            for (int j = 0; j < taskList.Count; j++)
            {
               
                    Console.WriteLine("Task {0}\n Name: {1}\n Description: {2}\n Deadline: {3} ", j + 1, taskList[j].name, taskList[j].description, taskList[j].deadline);
                    Console.WriteLine($"Status: {(taskList[j].completed == false ? "Incomplete" : "Complete")}\n");

               
            }
        }

        static void Main(string[] args)
        {
            //list of task objects
            List<Task> taskList = new List<Task>();
            while (true)
            {
                //looping menu of the choices 
                Console.WriteLine("Welcome to Assignment 1!\nPlease select an option ");
                Console.WriteLine("1. Create a new task");
                Console.WriteLine("2. Delete an existing task");
                Console.WriteLine("3. Edit an existing task");
                Console.WriteLine("4. Complete a task");
                Console.WriteLine("5. List all incompleted tasks");
                Console.WriteLine("6. List all tasks");
                Console.WriteLine("7. Exit");
                Console.Write("Selection: ");
                Console.Write("\n");
                var selection = Console.ReadLine();
                //converts from a string to an integer
               if(int.TryParse(selection, out int intselection))
                {
                    switch (intselection)
                    {
                        //case numbers are equivalent to menu choice 
                        //add task 
                        case 1:
                            Task t1 = new Task();
                            Console.WriteLine("Please enter the name of the task.");
                            t1.name = Console.ReadLine();
                            Console.WriteLine("Please enter the description of the task.");
                            t1.description = Console.ReadLine();
                            Console.WriteLine("Please enter the deadline of the task.");
                            t1.deadline = Console.ReadLine();
                            t1.completed = false;
                            //task object is added to list
                            taskList.Add(t1);
                            break;
                        //delete task
                        //asks user which task they would like to delete and uses removeat
                        case 2:
                            Console.WriteLine("Which task would you like to delete?");
                            Console.WriteLine("Select a task 1-{0}", taskList.Count);
                            Console.Write("Task # to delete: ");
                           
                            var tasknum = Console.ReadLine();
                            Console.WriteLine("\n");
                            if (int.TryParse(tasknum, out int taskselect))
                            {
                                if (taskselect > 0 && taskselect <= taskList.Count)
                                {
                                    taskList.RemoveAt(taskselect - 1);
                                }
                                else
                                    Console.WriteLine("Invalid index");

                            }
                                break;
                        case 3:
                            //edit task
                            //asks which task they would like to edit and goes through entire task
                            //will also ask if they would like to mark task as complete
                            Console.WriteLine("Which task would you like to edit?");
                            Console.WriteLine("Select a task 1-{0}", taskList.Count);
                            Console.Write("Task # to edit: ");
                            
                            var tasknum2 = Console.ReadLine();
                            Console.WriteLine("\n");
                            if (int.TryParse(tasknum2, out int taskselect2))
                            {
                                if (taskselect2 > 0 && taskselect2 <= taskList.Count)
                                {
                                    Console.WriteLine("Please enter the name of the task.");
                                    taskList[taskselect2 - 1].name = Console.ReadLine();
                                    Console.WriteLine("Please enter the description of the task.");
                                    taskList[taskselect2 - 1].description = Console.ReadLine();
                                    Console.WriteLine("Please enter the deadline of the task.");
                                    taskList[taskselect2 - 1].deadline = Console.ReadLine();
                                    Console.Write("Is this task completed? (y/n): ");
                                    var answer = Console.ReadLine();
                                    if (answer == "Y" || answer == "y")
                                        taskList[taskselect2 - 1].completed = true;
                                    else if (answer == "N" || answer == "n")
                                        taskList[taskselect2 - 1].completed = true;
                                }
                                else
                                    Console.WriteLine("Invalid index");
                            }
                            break;
                        case 4:
                            //complete a task
                            //switches boolean to true
                            Console.WriteLine("Which task would you like to mark complete?");
                            Console.WriteLine("Select a task 1-{0}", taskList.Count);
                            Console.Write("Task # to mark complete: ");
                            var tasknum1 = Console.ReadLine();
                            Console.WriteLine("\n");
                            if (int.TryParse(tasknum1, out int taskselect1))
                            {
                                taskList[taskselect1-1].completed = true;
                            }
                                break;
                        case 5:
                            //function above for printing incomplete tasks
                            printListInc(taskList);
                            break;

                        case 6:
                            //function above for printing all tasks
                            printList(taskList);
                            break;

                        case 7:
                            //Leave gracefully
                            Environment.Exit(-1);
                            break;
                    }
                }
            }

        }
    }
}
