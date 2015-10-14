using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi103.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext _dbcontext)
        {
            if (_dbcontext == null)
            {
                throw new NullReferenceException("invalid");
            }
            dbcontext = _dbcontext;
            set = dbcontext.Set<T>();
        }

        protected DbContext dbcontext { get; set; }
        protected DbSet<T> set { get; set; }


        public void Create(T context)
        {
            DbEntityEntry dbEntityEntry = dbcontext.Entry(context);
         
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
              set.Add(context);
            }
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return set;
        }

        public T GetId(int Id)
        {
            return set.Find(Id);
        }

        public void Update(T context)
        {
            throw new NotImplementedException();
        }
    }
}
