using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi103.Models;

namespace WebApi103.Data
{
    public class UOW : IUOW,IDisposable
    {
        private MyDBContext dbcontext { get; set; }
        Repository<Person> _person;

        public UOW()
        {
            CreateDbContext();
        }

        protected void CreateDbContext()
        {
            dbcontext = new MyDBContext();

            // Do NOT enable proxied entities, else serialization fails.
            //if false it will not get the associated certification and skills when we
            //get the applicants
            dbcontext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            dbcontext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            dbcontext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        public IRepository<Person> person
        {
            get
            {
                if (_person == null)
                {
                    _person = new Repository<Person>(dbcontext);
                }

                return _person;
            }
        }

        public void Commit()
        {
            dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbcontext != null)
                {
                    dbcontext.Dispose();
                }
            }
        }
    }
}
