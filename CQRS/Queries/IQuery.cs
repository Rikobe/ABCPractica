using System;
using System.Collections.Generic;
using System.Text;
using WebApiTesting.Models;
using RepositoryPattern.Common.Data;

namespace CQRS.Queries
{
    public interface IQuery
    {
        Wrapper<IEnumerable<Productos>> GetAllProductos();
    }
}
