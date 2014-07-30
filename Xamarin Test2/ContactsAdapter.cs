using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin_Test2.Parcelable;

namespace Xamarin_Test2
{
    class ContactsAdapter : BaseAdapter<Contact>
    {
        List<Contact> items;
        Activity context;

        public ContactsAdapter(Activity context, List<Contact> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }

        public override Contact this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return base.GetItem(position);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ContactListItem, null);
            }

            view.FindViewById<TextView>(Resource.Id.FirstName).Text = item.First_Name;
            view.FindViewById<TextView>(Resource.Id.LastName).Text = item.Last_Name;
            view.FindViewById<TextView>(Resource.Id.Mobile).Text = item.Mobile.ToString();
            view.FindViewById<TextView>(Resource.Id.EmailAddress).Text = item.Email;

            return view;
        }
    }
}