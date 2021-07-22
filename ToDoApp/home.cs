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
    public class home : AppCompatActivity
    {
        ListView lstViewData;

        List<Resources.Moldels.Task> listSource = new List<Resources.Moldels.Task>();
        Android.Widget.Button add;
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.tasks);
            db = new Database();
            db.createDatabase();
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
            add = FindViewById<Button>(Resource.Id.btnAdd);
            var a= FindViewById<CheckBox>(Resource.Id.listTask);
            add.Click += new EventHandler(Btntest1_Clicked);
            LoadData();
           
            lstViewData.ItemClick += (s, e) =>
            {
                for (int i = 0; i <= lstViewData.Count; i++)
                {
                    if (e.Position == i)
                    {
                        if (lstViewData.GetChildAt(i).Tag.ToString() == "false")
                        {
                            e.View.FindViewById<CheckBox>(Resource.Id.listTask).Checked = true;

                            lstViewData.GetChildAt(i).Tag = "true";
                            lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.SlateGray);
                            db.updateStatus(e.Id, true);
                        }
                        else if (lstViewData.GetChildAt(i).Tag.ToString() == "true")
                        {
                            e.View.FindViewById<CheckBox>(Resource.Id.listTask).Checked = false;
                            lstViewData.GetChildAt(i).Tag = "false";
                            lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                            db.updateStatus(e.Id, false);
                        }
                        else
                        {
                            e.View.FindViewById<CheckBox>(Resource.Id.listTask).Checked = true;
                            lstViewData.GetChildAt(i).Tag = "true";
                            lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.SlateGray);
                            db.updateStatus(e.Id, true);
                        }
                    }
                }
            };
        }
        private void Btntest1_Clicked(object sender, EventArgs e)
        {
                Intent intent = new Intent(this, typeof(tasks));
                StartActivity(intent);
        }
        private void LoadData()
        {

            listSource = db.selectTable();
            try
            {
                    var adapter = new ListViewAdapter(this, listSource);
                    lstViewData.Adapter = adapter;
            

                }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error");
            }
        }
    }
}