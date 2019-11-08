using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RepositoryPattern.Common.Data
{
    public class ExampleRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext _context;
        public ExampleRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            //IQueryable<T> query = _context.Set<T>();

            //return query;
            throw new InvalidProgramException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
