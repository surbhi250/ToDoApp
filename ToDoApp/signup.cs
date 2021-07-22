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
    public class signup : AppCompatActivity
    {
        Android.Widget.EditText userTxt;
        Android.Widget.EditText pswdTxt;
        Android.Widget.Button signBtn;
        Android.Widget.TextView loginBtn;
        Database db;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.signUP);
            db = new Database();
            db.createDatabase();
            userTxt = FindViewById<EditText>(Resource.Id.signUser);
            pswdTxt = FindViewById<EditText>(Resource.Id.signPswd);
            signBtn = FindViewById<Button>(Resource.Id.btnSignup);
            signBtn.Click += new EventHandler(Btntest1_Clicked);
            loginBtn = FindViewById<TextView>(Resource.Id.txtLogin);
            loginBtn.Click += new EventHandler(Btntest2_Clicked);
        }

        // logging screen
        private void Btntest1_Clicked(object sender, EventArgs e)
        {
            String usr = userTxt.Text.ToString();
            String pwd = pswdTxt.Text.ToString();
            if (usr!="" && pwd != "")
            {
                Resources.Moldels.User newUser = new Resources.Moldels.User()
                {
                    user = usr,
                    pswd = pwd
                };
                db.insertIntoUser(newUser);
                Intent intent = new Intent(this, typeof(home));
                StartActivity(intent);
            }
            else
            {
                    Toast.MakeText(Application.Context, "Invalid Username / Password", ToastLength.Short).Show();
            }
        }

        private void Btntest2_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}