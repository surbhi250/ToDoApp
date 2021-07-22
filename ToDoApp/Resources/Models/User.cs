using SQLite;
using System;

namespace ToDoApp.Resources.Moldels
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int userID { get; set; }
        public string user { get; set; }
        public string pswd { get; set; }
    }
}