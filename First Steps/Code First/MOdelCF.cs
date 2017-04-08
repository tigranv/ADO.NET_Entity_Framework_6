namespace Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MOdelCF : DbContext
    {
        // Your context has been configured to use a 'MOdelCF' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Code_First.MOdelCF' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MOdelCF' 
        // connection string in the application configuration file.
        public MOdelCF()
            : base("name=MOdelCF")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<PersonalInfo> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}