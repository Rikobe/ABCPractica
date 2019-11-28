using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTesting.Models;
using RepositoryPattern.Common.Data;
using WebApiTesting.Queries;
using WebApiTesting.Commands;

namespace WebApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IQuery _queries;
        private readonly ICommand _commands;
        
        public ProductosController(IQuery queries, ICommand commands)
        {
            _queries = queries;
            _commands = commands;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public Wrapper<IEnumerable<Productos>> GetProductos()
        {
            return _queries.GetAllProductos();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public Wrapper<IEnumerable<Productos>>  GetProductos(long id)
        {       
            return _queries.GetProductosById(id);
        }

        [HttpPut("{id}")]
        public Wrapper<Productos> PutProductos(long id, Productos producto)
        {
            return _commands.EditProducto(id, producto);
        }

        //// POST: api/Productos
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        ///
        [HttpPost]
        public Wrapper<Productos> PostProductos(Productos producto)
        {
            return _commands.SaveProducto(producto);
        }

        //// DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public Wrapper<Productos> DeleteProductos(long id)
        {
            return _commands.DeleteProducto(id);
        }
    }
}
