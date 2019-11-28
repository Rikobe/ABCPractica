using System;
using System.Collections.Generic;
using System.Text;
using WebApiTesting.Models;
using RepositoryPattern.Common.Data;

namespace CQRS.Queries
{
    class QueryService : IQuery
    {
        private readonly IGenericRepository<Productos> _repository;
        public QueryService (IGenericRepository<Productos> repository)
        {
            _repository = repository;
        }
        public Wrapper<IEnumerable<Productos>> GetAllProductos()
        {
            Wrapper<IEnumerable<Productos>> wrapper = new Wrapper<IEnumerable<Productos>>();
            
            wrapper.Result = _repository.GetAll();

            if (wrapper.Result == null)
            {
                wrapper.Success = false;
            }
            else
            {
                wrapper.Success = true;
            }
                     
            return wrapper;
        }
    }
}
