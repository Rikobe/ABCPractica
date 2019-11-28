using System;
using System.Collections.Generic;
using System.Text;
using WebApiTesting.Models;
using RepositoryPattern.Common.Data;

namespace WebApiTesting.Queries
{
    public class QueryService : IQuery
    {
        private readonly IRepository<Productos> _repository;
        public QueryService (IRepository<Productos> repository)
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

        public Wrapper<IEnumerable<Productos>> GetProductosById(long id)
        {
            Wrapper<IEnumerable<Productos>> wrapper = new Wrapper<IEnumerable<Productos>>();

            wrapper.Result = _repository.Find(producto => producto.ProductoId == id);

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
