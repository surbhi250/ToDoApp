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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Android.Widget.EditText user;
        Android.Widget.EditText pswd;
        Android.Widget.Button btn;
        Android.Widget.TextView btnSign;
        Database db;
        List<Resources.Moldels.User> listSource = new List<Resources.Moldels.User>();

        protected override void OnCreate(Bundle savedInstanceState)
        {  
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            db = new Database();
            db.createDatabase();


            user = FindViewById<EditText>(Resource.Id.editUser);
            pswd = FindViewById<EditText>(Resource.Id.editPswd);
            btn = FindViewById<Button>(Resource.Id.btnLogin);
            btn.Click += new EventHandler(Btntest1_Clicked);
            btnSign = FindViewById<TextView>(Resource.Id.txtSign);
            btnSign.Click += new EventHandler(Btntest2_Clicked);
        }
        private void Btntest1_Clicked(object sender, EventArgs e)
        {

            String usr = user.Text.ToString();
            String pwd = pswd.Text.ToString();
            listSource = db.checkUser(usr,pwd);
                if (usr.Equals("admin") && pwd.Equals("12345"))
                {
                    Intent intent = new Intent(this, typeof(home));
                    StartActivity(intent);
                }
                else if(listSource.Count!=0)
                {
           //     try
                //{
                  //  Console.WriteLine("Elemtnts ->" + listSource[0].ToString());
                    Intent intent = new Intent(this, typeof(home));
                    StartActivity(intent);
                /*      }
                      catch (NullReferenceException ex)
                      {
                          Toast.MakeText(Application.Context, "Invalid Login / Username", ToastLength.Short).Show();
                     }
                  */
            }
            else
            {
                Toast.MakeText(Application.Context, "Invalid Login / Username", ToastLength.Short).Show();
            }
        }

        private void Btntest2_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(signup));
            StartActivity(intent);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}