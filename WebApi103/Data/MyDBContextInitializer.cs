using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi103.Data
{
    public class MyDBContextInitializer:System.Data.Entity.DropCreateDatabaseAlways<MyDBContext>
    {

        public MyDBContextInitializer()
        { }

    }
}
