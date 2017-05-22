using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClientCRM
{
    public class Contact
    {
        public Contact()
        {
            this.EmailLists = new HashSet<EmailList>();
        }

        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public System.Guid GuID { get; set; }
        public System.DateTime DateInserted { get; set; }

        public virtual ICollection<EmailList> EmailLists { get; set; }
    }

    public partial class EmailList
    {
        public EmailList()
        {
            this.Contacts = new HashSet<Contact>();
        }

        public int EmailListID { get; set; }
        public string EmailListName { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
