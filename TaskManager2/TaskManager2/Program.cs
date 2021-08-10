// Name: Jack Garthwaite
// Assignment: Assignment 2
// Date: 6/15/2021
// Second phase of Item manager app


using System;
using System.Collections.Generic;

namespace TaskManager2
{

    class Program
    {

        //function to print list of incompleted tasks
        static void printListInc(List<Item> ItemList, int pageSize)
        {
            var currentPage = 0;

            //this bool is used to determine when a user is done browsing pages
            var paging = true;

            while (paging)
            {
                //this for loop is the majority of the actual paging implementation:
                //  We start at the current page by multiplying that page by the number of things on the page (this is the part that 0-based counting helps with)
                //  We keep repeating the body of the loop until we reach the end of that page by counting off pageSize ItemList
                //  We also have the i < ItemList.Count check to make sure that if we have, say, 17 ItemList we don't try to list the 18th item when going to the fourth page
                for (int i = currentPage * pageSize; i < (currentPage * pageSize) + pageSize && i < ItemList.Count; i++)
                {
                    var task = ItemList[i];
                   // Console.WriteLine("Status of thing is: {0}", ItemList[i].completed);
                        if (task is Task)
                    {
                        if ((task as Task).completed == false)
                        {
                            //print the page contents (i.e., the next pageSize ItemList in the list)
                            Console.WriteLine("{0}. (Task) Name: {1}\n Description: {2}\n Complete?: {3}\n Deadline: {4}\n", i + 1, ItemList[i].name, ItemList[i].description, (task as Task).completed, (task as Task).deadline);
                        }
                    }

                }
                    

                //if we have progressed past the first page, show a "Previous" option to allow backward navigation
                if (currentPage > 0)
                {
                    Console.WriteLine($"p - Previous");
                }

                //if we have other pages after this one, show a "Next" option to allow forward navigation
                if (ItemList.Count > (currentPage * pageSize) + pageSize)
                {
                    Console.WriteLine($"n - Next");
                }

                //if we are past the first page OR if there are other pages OR both, we need to display navigation options
                if (currentPage > 0 || ItemList.Count > currentPage + pageSize)
                {
                    //accept navigation from the user
                    string navigation = Console.ReadLine();

                    //this is technically technical debt because what it is doing doesn't make sense right now.
                    //But, let's take a look. We are checking to see if navigation is a valid int. If it isn't, 
                    //  TryParse will return false. Remember, that our prompts are p/n.
                    if (!int.TryParse(navigation, out int intNav))
                    {
                        //user didn't type an int
                        if (navigation.Equals("p", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //user typed either "p" OR "P" OR "p" with some sort of accent that was ASCII reduced to "p"
                            //go to the previous page
                            currentPage--;
                        }
                        else if (navigation.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //user typed either "n" OR "N" OR "n" with some sort of accent that was ASCII reduced to "n"
                            //go to the next page
                            currentPage++;
                        }
                        else
                        {
                            //user typed some non-int nonsense, so we go back to the beginning of the program. This is the most trivial defensive code for this situation.
                            paging = false;
                        }
                    }
                    else
                    {
                        //user typed some int (potentially nonsense (e.g., -938)), so we go back to the beginning of the program. This is the most trivial defensive code for this situation.
                        paging = false;
                    }
                }
                else
                {
                    //there are not enough ItemList to page, no input needed
                    paging = false;
                }

                //So, what's with the TryParse? This is a very trivial navigation setup. As it is, if the user chooses anything that isn't a navigation option, they are sent back to the beginning.
                //  typically this is not what you want. When the user chooses an item on a page, you want to handle that by displaying a description of that item or something of that nature.
                //  the bit that I marked as technical debt above is really a "special" type of technical debt that makes extensibility easier. With this implementation, you can easily find
                //  where you would add the code to support displaying descriptions and where you would add defensive code to check for valid page item selection.
                //  Pros: 
                //      - scaffolding provides a clear place to extend the application to include new features
                //  Cons:
                //      - a new person on the project might read the TryParse and the VS suggestion to remove intNav and either get confused or remove it and nullify the pro
                Console.WriteLine("Press enter to return to main menu");
            }
        }


        //function to print list of all Items
        static void printList(List<Item> ItemList, int pageSize)
        {
            var currentPage = 0;

            //this bool is used to determine when a user is done browsing pages
            var paging = true;
            while (paging)
            {
                //this for loop is the majority of the actual paging implementation:
                //  We start at the current page by multiplying that page by the number of things on the page (this is the part that 0-based counting helps with)
                //  We keep repeating the body of the loop until we reach the end of that page by counting off pageSize ItemList
                //  We also have the i < ItemList.Count check to make sure that if we have, say, 17 ItemList we don't try to list the 18th item when going to the fourth page
                for (int i = currentPage * pageSize; i < (currentPage * pageSize) + pageSize && i < ItemList.Count; i++)
                {
                    var task = ItemList[i];
                    //print the page contents (i.e., the next pageSize ItemList in the list)
                    if (ItemList[i] is Task)
                    {
                        Console.WriteLine("{0}. (Task) Name: {1}\n Description: {2}\n Complete?: {3}\n Deadline: {4}\n", i + 1, ItemList[i].name, ItemList[i].description, (task as Task).completed, (task as Task).deadline);
                    }
                    else if(ItemList[i] is Appointment)
                    {
                        
                        var people = (task as Appointment).Attendees;
                        Console.WriteLine("{0}. (Appointment) Name: {1}\n Description: {2}\n Start Time: {3}\n Stop Time: {4}\n  ", i + 1, ItemList[i].name, ItemList[i].description, (task as Appointment).start, (task as Appointment).stop);
                        for(int j = 0; j < people.Count-1; j++)
                        {
                            Console.WriteLine(people[j]);
                        }
                        Console.Write("\n");
                    }
                }

                //if we have progressed past the first page, show a "Previous" option to allow backward navigation
                if (currentPage > 0)
                {
                    Console.WriteLine($"p - Previous");
                }

                //if we have other pages after this one, show a "Next" option to allow forward navigation
                if (ItemList.Count > (currentPage * pageSize) + pageSize)
                {
                    Console.WriteLine($"n - Next");
                }

                //if we are past the first page OR if there are other pages OR both, we need to display navigation options
                if (currentPage > 0 || ItemList.Count > currentPage + pageSize)
                {
                    //accept navigation from the user
                    string navigation = Console.ReadLine();

                    //this is technically technical debt because what it is doing doesn't make sense right now.
                    //But, let's take a look. We are checking to see if navigation is a valid int. If it isn't, 
                    //  TryParse will return false. Remember, that our prompts are p/n.
                    if (!int.TryParse(navigation, out int intNav))
                    {
                        //user didn't type an int
                        if (navigation.Equals("p", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //user typed either "p" OR "P" OR "p" with some sort of accent that was ASCII reduced to "p"
                            //go to the previous page
                            currentPage--;
                        }
                        else if (navigation.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //user typed either "n" OR "N" OR "n" with some sort of accent that was ASCII reduced to "n"
                            //go to the next page
                            currentPage++;
                        }
                        else
                        {
                            //user typed some non-int nonsense, so we go back to the beginning of the program. This is the most trivial defensive code for this situation.
                            paging = false;
                        }
                    }
                    else
                    {
                        //user typed some int (potentially nonsense (e.g., -938)), so we go back to the beginning of the program. This is the most trivial defensive code for this situation.
                        paging = false;
                    }
                }
                else
                {
                    //there are not enough ItemList to page, no input needed
                    paging = false;
                }

                //So, what's with the TryParse? This is a very trivial navigation setup. As it is, if the user chooses anything that isn't a navigation option, they are sent back to the beginning.
                //  typically this is not what you want. When the user chooses an item on a page, you want to handle that by displaying a description of that item or something of that nature.
                //  the bit that I marked as technical debt above is really a "special" type of technical debt that makes extensibility easier. With this implementation, you can easily find
                //  where you would add the code to support displaying descriptions and where you would add defensive code to check for valid page item selection.
                //  Pros: 
                //      - scaffolding provides a clear place to extend the application to include new features
                //  Cons:
                //      - a new person on the project might read the TryParse and the VS suggestion to remove intNav and either get confused or remove it and nullify the pro
                Console.WriteLine("Press enter to return to main menu");
            }
        }


        static void Main(string[] args)
        {
            var pageSize = 5;
            //list of Item objects
            List<Item> ItemList = new List<Item>();
         
            while (true)
            {
                //looping menu of the choices 
                Console.WriteLine("Welcome to Assignment 1!\nPlease select an option ");
                Console.WriteLine("1. Create a new Item");
                Console.WriteLine("2. Delete an existing Item");
                Console.WriteLine("3. Edit an existing Item");
                Console.WriteLine("4. Complete a Item");
                Console.WriteLine("5. List all incompleted Items");
                Console.WriteLine("6. List all Items");
                Console.WriteLine("7. Search");
                Console.WriteLine("8. Exit");
                Console.Write("Selection: ");
                Console.Write("\n");
                var selection = Console.ReadLine();
                //converts from a string to an integer
                if (int.TryParse(selection, out int intselection))
                {
                    switch (intselection)
                    {
                        //case numbers are equivalent to menu choice 
                        //add Item 
                        case 1:
                            //When creating there is a distinction between a task and an appointment
                            Console.WriteLine("Would you like to create a Task or an Appointment? (T/A)");
                            var TorA = Console.ReadLine();     
                            if (TorA == "T" || TorA == "t")
                            {   //new task object is created, mostly unchanged except for including the deadline from the derived task class
                                Task t1 = new Task();
                                Console.WriteLine("Please enter the name of the Item.");
                                t1.name = Console.ReadLine();
                                Console.WriteLine("Please enter the description of the Item.");
                                t1.description = Console.ReadLine();
                                Console.WriteLine("Please enter the deadline of the Item. (MM/DD/YYYY HH:MM:SS AM/PM)");
                                string dateInput;
                                dateInput = Console.ReadLine();
                                DateTime dt;
                                var isValidDate = DateTime.TryParse(dateInput, out dt);
                                if (isValidDate)
                                    t1.deadline = dt;
                                else
                                    Console.WriteLine("Not a valid string");
                                t1.completed = false;
                                //Item object is added to list
                                ItemList.Add(t1);
                            }
                            else if (TorA == "A" || TorA == "a")
                            {
                                //this is all new, using the derived appointment class an appointment object is created and filled out then added to ItemList
                                Appointment a1 = new Appointment();
                                Console.WriteLine("Please enter the name of the Item.");
                                a1.name = Console.ReadLine();
                                Console.WriteLine("Please enter the description of the Item.");
                                a1.description = Console.ReadLine();
                                Console.WriteLine("Please enter the start date/time of the Item. (MM/DD/YYYY HH:MM:SS AM/PM)");
                                string dateInput;
                                dateInput = Console.ReadLine();
                                DateTime dt;
                                var isValidDate = DateTime.TryParse(dateInput, out dt);
                                if (isValidDate)
                                    a1.start = dt;
                                else
                                    Console.WriteLine("Not a valid string");
                                Console.WriteLine("Please enter the stop date/time of the Item. (MM/DD/YYYY HH:MM:SS AM/PM)");
                                dateInput = Console.ReadLine();
                                isValidDate = DateTime.TryParse(dateInput, out dt);
                                if (isValidDate)
                                {
                                    Console.WriteLine("valid string");
                                    a1.stop = dt;
                                }
                                else
                                    Console.WriteLine("Not a valid string");
                                Console.WriteLine("Please enter the appointment attendees (enter done when finished):");
                                string input = "";
                                var attend = new List<string>();
                                while (input != "done")
                                {
                                    input = Console.ReadLine();
                                    attend.Add(input);
                                };
                                a1.Attendees = attend;
                                //Item object is added to list
                                ItemList.Add(a1);
                            }
                            break;
                        //delete Item
                        //asks user which Item they would like to delete and uses removeat
                        case 2:
                            Console.WriteLine("Which Item would you like to delete?");
                            Console.WriteLine("Select a Item 1-{0}", ItemList.Count);
                            Console.Write("Item # to delete: ");

                            var Itemnum = Console.ReadLine();
                            Console.WriteLine("\n");
                            if (int.TryParse(Itemnum, out int Itemselect))
                            {
                                if (Itemselect > 0 && Itemselect <= ItemList.Count)
                                {
                                    ItemList.RemoveAt(Itemselect - 1);
                                }
                                else
                                    Console.WriteLine("Invalid index");

                            }
                            break;
                        case 3:
                            //edit Item
                            //asks which Item they would like to edit and goes through entire Item
                            //will also ask if they would like to mark Item as complete
                            Console.WriteLine("Which Item would you like to edit?");
                            Console.WriteLine("Select a Item 1-{0}", ItemList.Count);
                            Console.Write("Item # to edit: ");

                            var Itemnum2 = Console.ReadLine();
                            Console.WriteLine("\n");
                            if (int.TryParse(Itemnum2, out int Itemselect2))
                            {
                                //error checking and DateTime was added instead of a string
                                if (Itemselect2 > 0 && Itemselect2 <= ItemList.Count)
                                {
                                    var task = ItemList[Itemselect2 - 1];
                                    if (task is Task)
                                    {
                                        Console.WriteLine("Please enter the name of the Item.");
                                        ItemList[Itemselect2 - 1].name = Console.ReadLine();
                                        Console.WriteLine("Please enter the description of the Item.");
                                        ItemList[Itemselect2 - 1].description = Console.ReadLine();
                                        Console.WriteLine("Please enter the deadline of the Item. (MM/DD/YYYY HH:MM:SS AM/PM)");
                                        string dateInput;
                                        dateInput = Console.ReadLine();
                                        DateTime dt;
                                        var isValidDate = DateTime.TryParse(dateInput, out dt);
                                        //date is checked if valid
                                        if (isValidDate)
                                            (task as Task).deadline = dt;
                                        else
                                            Console.WriteLine("Not a valid string");
                                        Console.Write("Is this Item completed? (y/n): ");
                                        var answer = Console.ReadLine();
                                        if (answer == "Y" || answer == "y")
                                        {
                                            (task as Task).completed = true;
                                            ItemList[Itemselect2 - 1] = task;
                                        }
                                        else if (answer == "N" || answer == "n")
                                        {
                                            (task as Task).completed = false;
                                            ItemList[Itemselect2 - 1] = task;
                                        }
                                    }
                                    else if(task is Appointment)
                                    {   //name and description can be modified without using (task as Appointment)
                                        Console.WriteLine("Please enter the name of the Item.");
                                        ItemList[Itemselect2 - 1].name = Console.ReadLine();
                                        Console.WriteLine("Please enter the description of the Item.");
                                        ItemList[Itemselect2 - 1].description = Console.ReadLine();
                                        Console.WriteLine("Please enter the start date/time of the Item. (MM/DD/YYYY HH:MM:SS AM/PM)");
                                        string dateInput;
                                        dateInput = Console.ReadLine();
                                        DateTime dt;
                                        var isValidDate = DateTime.TryParse(dateInput, out dt);
                                        if (isValidDate)
                                            (task as Appointment).start = dt;
                                        else
                                            Console.WriteLine("Not a valid string");
                                        Console.WriteLine("Please enter the stop date/time of the Item. (MM/DD/YYYY HH:MM:SS AM/PM)");
                                        dateInput = Console.ReadLine();
                                        isValidDate = DateTime.TryParse(dateInput, out dt);
                                        if (isValidDate)
                                        {
                                            Console.WriteLine("valid string");
                                            (task as Appointment).stop = dt;
                                        }
                                        else
                                            Console.WriteLine("Not a valid string");
                                        Console.WriteLine("Please enter the appointment attendees:");
                                        string input = "";
                                        var attend = new List<string>();
                                        while (input != "done")
                                        {
                                            input = Console.ReadLine();
                                            attend.Add(input);
                                        };
                                        (task as Appointment).Attendees = attend;


                                    }
                                }
                                else
                                    Console.WriteLine("Invalid index");
                            }
                            break;
                        case 4:
                            //complete a Item
                            //switches boolean to true
                            Console.WriteLine("Which Item would you like to mark complete?");
                            Console.WriteLine("Select a Item 1-{0}", ItemList.Count);
                            Console.Write("Item # to mark complete: ");
                            var Itemnum1 = Console.ReadLine();
                            Console.WriteLine("\n");
                            if (int.TryParse(Itemnum1, out int Itemselect1))
                            {
                                var task = ItemList[Itemselect1 - 1];
                                //only change made here (task as Task)
                                (task as Task).completed = true;
                            }
                            break;
                        case 5:
                           
                            printListInc(ItemList, 5);
                            break;

                        case 6:
                            printList(ItemList, 5);
                            break;
                        case 7:
                            //search functionality made using loops instead of linq
                            //search variable is checked if contained in the name and description
                            //while checking if the ItemList object is an appointment
                            //if found to be an appointment it will also search all the attendees for a match
                            //otherwise no match prints out
                            Console.WriteLine("Please enter a string you would like to search for:");
                            string search = Console.ReadLine();
                            string upper = search;
                            upper = search.ToUpper();
                            string uppername, upperdescription, upperattendee;
                            
                            for(int i = 0; i < ItemList.Count; i++)
                            {
                                uppername = ItemList[i].name.ToUpper();
                                upperdescription = ItemList[i].description.ToUpper();
                                var task = ItemList[i];
                                if (uppername.Contains(upper))
                                {
                                    Console.WriteLine("The following name was a match: '{0}' \nFor the item: ", search);
                                    Console.WriteLine("{0}. (Task) Name: {1}\n Description: {2}\n Complete?: {3}\n Deadline: {4}\n", i + 1, ItemList[i].name, ItemList[i].description, (task as Task).completed, (task as Task).deadline);
                                }
                                else if (upperdescription.Contains(upper))
                                {
                                    Console.WriteLine("'{0}' matched the description of the following item: ", search);
                                    Console.WriteLine("{0}. (Task) Name: {1}\n Description: {2}\n Complete?: {3}\n Deadline: {4}\n", i + 1, ItemList[i].name, ItemList[i].description, (task as Task).completed, (task as Task).deadline);
                                }
                               else if (task is Appointment)
                                {
                                    var attend = (task as Appointment).Attendees;
                                    for (int j = 0; j < attend.Count; j++)
                                    {
                                        upperattendee = attend[j].ToUpper();
                                        if (upperattendee.Contains(upper))
                                        {
                                            Console.WriteLine("The following attendee: '{0}' was a match for the item: ", attend[j]);
                                            Console.WriteLine("{0}. (Appointment) Name: {1}\n Description: {2}\n Start Time: {3}\n Stop Time: {4}\n  ", i + 1, ItemList[i].name, ItemList[i].description, (task as Appointment).start, (task as Appointment).stop);
                                            for (int k = 0; k < attend.Count - 1; k++)
                                            {
                                                Console.WriteLine(attend[k]);
                                            }
                                            Console.Write("\n");
                                        }
                                    }
                                }
                                else
                                    Console.WriteLine("There weren't any matches");
                            }
                            
                            break;
                        case 8:
                            //Leave gracefully
                            Environment.Exit(-1);
                            break;
                        

                    }
                }
            }

        }
    }
}
