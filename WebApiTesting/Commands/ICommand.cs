using System;
using System.Collections.Generic;
using System.Text;
using WebApiTesting.Models;

namespace WebApiTesting.Commands
{
    public interface ICommand
    {
        Wrapper<Productos> SaveProducto(Productos producto);
        Wrapper<Productos> EditProducto(long id, Productos producto);
        Wrapper<Productos> DeleteProducto(long id);
    }
}
