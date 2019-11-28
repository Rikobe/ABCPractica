using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTesting.Models;
using RepositoryPattern.Common.Data;

namespace WebApiTesting.Commands
{
    public class CommandService : ICommand
    {
        private readonly IRepository<Productos> _repository;
        public CommandService(IRepository<Productos> repository)
        {
            _repository = repository;
        }
        public Wrapper<Productos> DeleteProducto(long id)
        {
            Wrapper<Productos> wrapper = new Wrapper<Productos>();

            if (_repository.Find(producto => producto.ProductoId == id) == null)
            {
                wrapper.Success = false;
            }
            else
            {
                wrapper.Success = true;
            }

            return wrapper;
        }

        public Wrapper<Productos> EditProducto(long id, Productos producto)
        {
            Wrapper<Productos> wrapper = new Wrapper<Productos>();
            if (id != producto.ProductoId)
            {
                wrapper.Success = false;
            }
            else
            {
                wrapper.Success = true;
                _repository.Edit(producto);
                _repository.Save();
                wrapper.Result = producto;
            }
            return wrapper;
        }

        public Wrapper<Productos> SaveProducto(Productos producto)
        {
            Wrapper<Productos> wrapper = new Wrapper<Productos>();

            _repository.Add(producto);
            _repository.Save();
            wrapper.Success = true;
            wrapper.Result = producto;

            return wrapper;
        }
    }
}
