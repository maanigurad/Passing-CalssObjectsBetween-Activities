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
    [Activity(Label = "ContactDetailsActivity")]
    public class ContactDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here

            SetContentView(Resource.Layout.ContactDetails);
            //Contact c = Intent.Extras.GetParcelable("selectedObject")as Contact;

            var intentBundle = Intent.Extras;
            Contact[] c = Intent.GetParcelableArrayListExtra("SelectedItem").Cast<Contact>().ToArray();
            if (c.Count() > 0)
            {
                Contact item  =  c[0];
                FindViewById<TextView>(Resource.Id.FirstName).Text = item.First_Name;
                FindViewById<TextView>(Resource.Id.LastName).Text = item.Last_Name;
                FindViewById<TextView>(Resource.Id.HomeAddress).Text = item.Home_Address;
                FindViewById<TextView>(Resource.Id.Suburb).Text = item.Suburb.ToString();
                FindViewById<TextView>(Resource.Id.PostCode).Text = item.Postcode.ToString();
                FindViewById<TextView>(Resource.Id.State).Text = item.State;
                FindViewById<TextView>(Resource.Id.Counrty).Text = item.Country;
                FindViewById<TextView>(Resource.Id.HomePhone).Text = item.Home_Phone.ToString();
                FindViewById<TextView>(Resource.Id.WorkPhone).Text = item.Work_Phone.ToString();
                FindViewById<TextView>(Resource.Id.Mobile).Text = item.Mobile.ToString();
                FindViewById<TextView>(Resource.Id.Email).Text = item.Email;
                FindViewById<TextView>(Resource.Id.LinkedinURl).Text = item.LinkedIn_URL;
                FindViewById<TextView>(Resource.Id.FacebookURL).Text = item.Facebook_URL;
            }
        }
    }
}