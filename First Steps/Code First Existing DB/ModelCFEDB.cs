namespace Code_First_Existing_DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCFEDB : DbContext
    {
        public ModelCFEDB()
            : base("name=ModelCFEDBcon")
        {
        }

        public virtual DbSet<PersonalInfo> PersonalInfoes { get; set; }

       
    }
}
