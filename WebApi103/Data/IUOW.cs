using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi103.Models;

namespace WebApi103.Data
{
   public interface IUOW
    {
        void Commit();
        IRepository<Person> person { get; }
    }
}
