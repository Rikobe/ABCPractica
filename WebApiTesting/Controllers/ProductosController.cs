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
       // private readonly InventarioContext _context;
        private readonly IGenericRepository<Productos> _repository;


        //public ProductosController(InventarioContext context,IGenericRepository<Productos> repository)
        public ProductosController(IGenericRepository<Productos> repository)
        {
            _repository = repository;
            //_context = context;
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
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Productos>> GetProductos(long id)
        //{
        //    var productos = await _context.Productos.FindAsync(id);

        //    if (productos == null)
        //    {
        //        return NotFound();
        //    }

        //    return productos;
        //}

        //// PUT: api/Productos/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProductos(long id, Productos productos)
        //{
        //    if (id != productos.ProductoId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(productos).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductosExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Productos
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        //{
        //    _context.Productos.Add(productos);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetProductos), new { id = productos.ProductoId }, productos);
        //}

        //// DELETE: api/Productos/5
        //[HttpDelete("{id}")]
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
