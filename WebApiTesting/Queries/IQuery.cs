using System;
using System.Collections.Generic;
using System.Text;
using WebApiTesting.Models;
using RepositoryPattern.Common.Data;

namespace WebApiTesting.Queries
{
    public interface IQuery
    {
        Wrapper<IEnumerable<Productos>> GetAllProductos();

        Wrapper<IEnumerable<Productos>> GetProductosById(long id);
    }
}
