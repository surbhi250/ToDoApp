using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace ToDoApp.Resources.Moldels
{
    public class ViewHolder
    {
        public CheckBox txtTitle { get; set; }
        public TextView txtdue { get; set; }
    }
    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Task> listTask;
        public ListViewAdapter(Activity activity, List<Task> listTasks)
        {
            this.activity = activity;
            this.listTask = listTasks;
        }

        public override int Count
        {
            get { return listTask.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return listTask[position].taskID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.listTask, parent, false);
            var txtTitle = view.FindViewById<CheckBox>(Resource.Id.txtTask) ?? new CheckBox(parent.Context);
            var txtDue = view.FindViewById<TextView>(Resource.Id.btnDue) ?? new TextView(parent.Context);
            txtTitle.Text = listTask[position].title;
            txtDue.Text = listTask[position].dueDate.ToString("dd MMMM yy hh:mm tt");
            txtTitle.Checked = listTask[position].status;
            return view;
        }
    }
}