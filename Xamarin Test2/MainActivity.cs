using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin_Test2.Parcelable;



namespace Xamarin_Test2
{
    [Activity(Label = "Xamarin_Test2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    { 
        ListView contactsListView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button buttonCreateTable = FindViewById<Button>(Resource.Id.buttonCreateTable);
            Button buttonLoad = FindViewById<Button>(Resource.Id.buttonLoadData);
            contactsListView = FindViewById<ListView>(Resource.Id.ContactsListView);
            ContactsRepository cr = new ContactsRepository();

            buttonCreateTable.Click += new EventHandler(ButtonInsertRecord_Click);
            buttonLoad.Click += new EventHandler(ButtonLoad_Click);
            contactsListView.ItemClick += new EventHandler<AdapterView.ItemClickEventArgs>(ContactsListView_ItemClick);
                
        }
        

        static void ButtonInsertRecord_Click(Object sender, EventArgs e)
        {
            
            ContactsRepository.DeleteContacts();
            for (int i = 0; i < 10; i++)
            {
                Contact c = new Contact
                {
                    First_Name = "Manni"+ "--" + i,
                    Last_Name = "Shirazi",
                    Email = i + "@gmail.com",
                    Facebook_URL = @"http://facebook.com/" + "--" + i,
                    Home_Address = "Shiraz",
                    Suburb = "Randwick",
                    State = "NSW",
                    Country = "Aus",
                    Postcode = 0711,
                    Mobile = i,
                    Home_Phone = i,
                    Work_Phone = i,
                };
                ContactsRepository.AddContact(c);
            }

        }
        private void ButtonLoad_Click(Object sender, EventArgs e)
        {
            
            var data = ContactsRepository.GetAllContacts();
            contactsListView.Adapter = new ContactsAdapter(this, data);
        }
        void ContactsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView != null)
            {

                var intent = new Intent(this, typeof(ContactDetailsActivity));
                // Put the items list into the intent
                var value = this.contactsListView.Adapter.GetItem(e.Position);
                Contact c = value.JavaCast<Contact>();
                Contact[] lst = new Contact[]{c};
                intent.PutParcelableArrayListExtra("SelectedItem", lst);
                StartActivity(intent);
            }

        }
    }
}
