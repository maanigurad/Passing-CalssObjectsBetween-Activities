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
using Java.Interop;
using SQLite;

namespace Xamarin_Test2.Parcelable
{
    public sealed class Contact : Java.Lang.Object, IParcelable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Home_Address { get; set; }
        public string Suburb { get; set; }
        public int Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Home_Phone { get; set; }
        public int Work_Phone { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
        public string LinkedIn_URL { get; set; }
        public string Facebook_URL { get; set; }

        public Contact() { }
        private Contact(Parcel parcel)
        {
            ID = parcel.ReadInt();
            First_Name = parcel.ReadString();
            Last_Name = parcel.ReadString();
            Home_Address = parcel.ReadString();
            Suburb = parcel.ReadString();
            Postcode = parcel.ReadInt();
            State = parcel.ReadString();
            Country = parcel.ReadString();
            Home_Phone = parcel.ReadInt();
            Work_Phone = parcel.ReadInt();
            Mobile = parcel.ReadInt();
            Email = parcel.ReadString();
            LinkedIn_URL = parcel.ReadString();
            Facebook_URL = parcel.ReadString();
        }
        public int DescribeContents()
        {
            return 0;
        }
        // Save this instance's values to the parcel
        public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            dest.WriteInt(ID);
            dest.WriteString(First_Name);
            dest.WriteString(Last_Name);
            dest.WriteString(Home_Address);
            dest.WriteString(Suburb);
            dest.WriteInt(Postcode);
            dest.WriteString(State);
            dest.WriteString(Country);
            dest.WriteInt(Home_Phone);
            dest.WriteInt(Work_Phone);
            dest.WriteInt(Mobile);
            dest.WriteString(Email);
            dest.WriteString(LinkedIn_URL);
            dest.WriteString(Facebook_URL);

        }
        // The creator creates an instance of the specified object
        private static readonly GenericParcelableCreator<Contact> _creator
            = new GenericParcelableCreator<Contact>((parcel) => new Contact(parcel));

        [ExportField("CREATOR")]
        public static GenericParcelableCreator<Contact> GetCreator()
        {
            return _creator;
        }
    }
    public sealed class GenericParcelableCreator<T> : Java.Lang.Object, IParcelableCreator
    where T : Java.Lang.Object, new()
    {
        private readonly Func<Parcel, T> _createFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelableDemo.GenericParcelableCreator`1"/> class.
        /// </summary>
        /// <param name='createFromParcelFunc'>
        /// Func that creates an instance of T, populated with the values from the parcel parameter
        /// </param>
        public GenericParcelableCreator(Func<Parcel, T> createFromParcelFunc)
        {
            _createFunc = createFromParcelFunc;
        }

        #region IParcelableCreator Implementation

        public Java.Lang.Object CreateFromParcel(Parcel source)
        {
            return _createFunc(source);
        }

        public Java.Lang.Object[] NewArray(int size)
        {
            return new T[size];
        }

        #endregion
    }
}