using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi103.Models;

namespace WebApi103.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MyDBContext:DbContext
    {
        public MyDBContext() : base("Name=MyDB")
        {
           
            Database.SetInitializer(new DropCreateDatabaseAlways<MyDBContext>());
        }

        public DbSet<Person> person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
           
        }

       
    }
}

