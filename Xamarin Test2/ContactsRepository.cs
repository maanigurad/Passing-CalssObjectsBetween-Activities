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
using SQLite;
using Java.Interop;
using Xamarin_Test2.Parcelable;

namespace Xamarin_Test2
{

    public class ContactsRepository
    {
        internal static SQLiteConnection DB;

        public ContactsRepository()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            DB = new SQLiteConnection(System.IO.Path.Combine(folder, "Contacts.db"));
            DB.CreateTable<Contact>();
        }

        public static void AddContact(Contact c)
        {
            DB.Insert(c);
        }

        public static List<Contact> GetAllContacts()
        {
            return DB.Table<Contact>().ToList();
        }


        public static void DeleteContacts()
        {
            DB.DeleteAll<Contact>();
        }
    }
}