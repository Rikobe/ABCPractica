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

namespace WebApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IGenericRepository<Productos> _repository;

        public ProductosController(IGenericRepository<Productos> repository)
        {
            _repository = repository;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public Wrapper<IEnumerable<Productos>> GetProductos()
        { 
            Wrapper<IEnumerable<Productos>> wrapper = new Wrapper<IEnumerable<Productos>>();
            wrapper.Success = true;
            //wrapper.Result = _context.Productos.ToList();
            wrapper.Result = _repository.GetAll();

            return wrapper;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public Wrapper<IEnumerable<Productos>>  GetProductos(long id)
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

        // PUT: api/Productos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        
        public Wrapper<Productos> PutProductos(long id, Productos producto)
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

        //// POST: api/Productos
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        ///
        
        [HttpPost]
        public Wrapper<Productos> PostProductos(Productos producto)
        {
            Wrapper<Productos> wrapper = new Wrapper<Productos>();

            _repository.Add(producto);
            _repository.Save();

            wrapper.Success = true;
            wrapper.Result = producto;

            return wrapper;
        }

        //// DELETE: api/Productos/5
        [HttpDelete("{id}")]
        
        public Wrapper<Productos> DeleteProductos(long id)
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
        //public async Task<ActionResult<Productos>> DeleteProductos(long id)
        //{
        //    var productos = await _context.Productos.FindAsync(id);
        //    if (productos == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Productos.Remove(productos);
        //    await _context.SaveChangesAsync();

        //    return productos;
        //}

        //private bool ProductosExists(long id)
        //{
        //    return _context.Productos.Any(e => e.ProductoId == id);
        //}
    }
}
