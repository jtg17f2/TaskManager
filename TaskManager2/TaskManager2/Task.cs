using System;
using System.Collections.Generic;

namespace TaskManager2
{
    public class Item
    {
        public string name;
        public string description;
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

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public object completed { get; internal set; }

        public Item()
        {
            name = "";
            description = "";

        }

        public override string ToString()
        {
            return $"{Name}\t{Description}";
        }

        public virtual string ToString(bool forInventory)
        {
            if (forInventory)
            {
                return $"{Name} {Description}";
            }

            return ToString();
        }

    }
    public class Appointment: Item
    {
        //public DateTime start = new DateTime();
        //public DateTime stop = {get;
        //public List<String> Attendees = new List<String>();
        public DateTime start { get; set; }
        public DateTime stop { get; set; }
        public List<string> Attendees { get; set; }
        public Appointment()
        {

        }
    }

    public class Task: Item
    {
        public DateTime deadline = new DateTime();
        public bool completed { get; set; }
        public Task()
        {

        }

    }
}
