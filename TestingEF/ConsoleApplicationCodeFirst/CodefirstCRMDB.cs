namespace ConsoleApplicationCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class CodefirstCRMDB : DbContext
    {
        // Your context has been configured to use a 'CodefirstCRMDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ConsoleApplicationCodeFirst.CodefirstCRMDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CodefirstCRMDB' 
        // connection string in the application configuration file.
        public CodefirstCRMDB()
            : base("name=CodefirstCRMDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<EmailList> EmailLists { get; set; }
    }


    public class EmailList
    {
        public int EmailListID { get; set; }
        public string EmailListName { get; set; }

        public ICollection<Partner> Partners { get; set; }

        public EmailList()
        {
            Partners = new List<Partner>();
        }
    }

    public class Partner
    {
        public int PartnerID { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public ICollection<EmailList> EmailLists { get; set; }

        public Partner()
        {
            EmailLists = new List<EmailList>();
        }
    }
}