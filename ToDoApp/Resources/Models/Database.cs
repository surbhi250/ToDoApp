using Android.Util;
using SQLite;
using ToDoApp.Resources.Moldels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ToDoApp.Resources.Moldels
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    connection.CreateTable<Task>();
                }
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "User.db")))
                {
                    connection.CreateTable<User>();
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool insertIntoTable(Task task)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    connection.Insert(task);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool insertIntoUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "User.db")))
                {
                    connection.Insert(user);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Task> selectTable()
        {

            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    return connection.Query<Task>("Select * from Task") ;
                }
            }
            catch (SQLiteException ex)
            {
                Resources.Moldels.Task newUser = new Resources.Moldels.Task()
                {
                    title = "New Task",
                    note = " ",
                    dueDate = Convert.ToDateTime("02/11/2021"),
                    remindDate = Convert.ToDateTime("02/11/2021"),
                    status = false
                };
                insertIntoTable(newUser);
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    return connection.Query<Task>("Select * from Task");
                }
            }
        }
        public List<User> checkUser(String u,String p)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "User.db")))
                {
                     return connection.Query<User>("Select * from User Where user=? and pswd=?", u, p);
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public bool updateTable(Task task)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    connection.Query<Task>("UPDATE Task set title=?, dueDate=?,remindDate=? Where taskID=?", task.title, task.note, task.dueDate, task.remindDate, task.taskID);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool updateStatus(long id,bool a)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    connection.Query<Task>("UPDATE Task set status=? Where taskID=?", a,id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool removeTable(Task task)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    connection.Delete(task);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Task.db")))
                {
                    connection.Query<Task>("SELECT * FROM Task Where taskID=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}