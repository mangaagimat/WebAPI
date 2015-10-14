﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi103.Data
{
   public interface IRepository<T> where T :class
    {
        IQueryable<T> GetAll();
        void Create(T context);
        void Update(T context);
        T GetId(int Id);
        void Delete(int Id);
            
    }
}