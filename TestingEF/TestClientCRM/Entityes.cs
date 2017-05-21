using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClientCRM
{
    public class Partner
    {
        public Partner()
        {
            this.EmailLists = new HashSet<EmailList>();
        }

        public int PartnerID { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public virtual ICollection<EmailList> EmailLists { get; set; }
    }

    public partial class EmailList
    {
        public EmailList()
        {
            this.Partners = new HashSet<Partner>();
        }

        public int EmailListID { get; set; }
        public string EmailListName { get; set; }

        public virtual ICollection<Partner> Partners { get; set; }
    }
}
