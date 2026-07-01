using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
       // private string text;
        public string Address { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string WorkPhone { get; set; } = "";

        public ContactData()
        {
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return firstname == other.firstname && lastname == other.lastname;
        }

        public override int GetHashCode()
        {
            return (firstname + lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + firstname + "\nlastname=" + lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int result = firstname.CompareTo(other.firstname);
            if (result != 0)
            {
                return result;
            }
            return lastname.CompareTo(other.lastname);
        }

        public ContactData (string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        [Column(Name = "firstname")]
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        [Column(Name = "lastname")]
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        [Column(Name = "id")]
        public string Id { get; set; }
        public string GetConcatenatedData()
        {
            return $"{Firstname}|{Lastname}|{Address}|{HomePhone}|{MobilePhone}|{WorkPhone}";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }

    }
    


    }
