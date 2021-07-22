using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using ToDoApp.Resources.Moldels;
using Android.Content;
using System.Collections.Generic;

namespace ToDoApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class tasks : AppCompatActivity
    {
        Android.Widget.EditText taskTxt;
        Android.Widget.EditText noteTxt;
        Android.Widget.Button addBtn;
        Android.Widget.EditText dueBtn;
        Android.Widget.Button remindBtn;
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.addTask);
            db = new Database();
            db.createDatabase();
            taskTxt = FindViewById<EditText>(Resource.Id.txtTask);
            noteTxt = FindViewById<EditText>(Resource.Id.txtNote);
            addBtn = FindViewById<Button>(Resource.Id.btnDone);
            addBtn.Click += new EventHandler(Btntest1_Clicked);
            dueBtn = FindViewById<EditText>(Resource.Id.btnDue);
            dueBtn.Click += (sender, e) =>
            {
                DateTime today = DateTime.Today;
                DatePickerDialog dialog = new DatePickerDialog(this, onDateSet, today.Year, today.Month - 1, today.Day);
                dialog.DatePicker.MinDate = today.Millisecond;
                dialog.Show();
            };
          //  dueBtn.Click += new EventHandler(Btntest2_Clicked);
       //     remindBtn = Find()ViewById<Button>(Resource.Id.btnRemind);
       //     remindBtn.Click += new EventHandler(Btntest3_Clicked);
        }
        void onDateSet(object sender,DatePickerDialog.DateSetEventArgs e)
        {
            dueBtn.Text = e.Date.ToLongDateString();
        }

        // saving task to database
        private void Btntest1_Clicked(object sender, EventArgs e)
        {
            if (taskTxt.Text != "")
            {
                Resources.Moldels.Task newUser = new Resources.Moldels.Task()
                {
                 title=taskTxt.Text.ToString(),
                    note= noteTxt.Text.ToString(),
                    dueDate= Convert.ToDateTime(dueBtn.Text.ToString()),
                    remindDate= Convert.ToDateTime(dueBtn.Text.ToString()),
                    status=false
                };
                db.insertIntoTable(newUser);
                Toast.MakeText(Application.Context, "Task Saved Successfuly", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, "Enter Task", ToastLength.Short).Show();
            }
        }

        private void Btntest2_Clicked(object sender, EventArgs e)
        {
        }
        private void Btntest3_Clicked(object sender, EventArgs e)
        {
        }
    }
}