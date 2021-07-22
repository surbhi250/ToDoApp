using SQLite;
using System;

namespace ToDoApp.Resources.Moldels
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int taskID { get; set; }
        public string title { get; set; }
        public string note { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime remindDate { get; set; }
        public bool status { get; set; }

    }
}