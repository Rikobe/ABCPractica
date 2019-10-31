using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTesting.Models
{
    public class Producto
    {
        public long ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Color { get; set; }
        public float PrecioUnitario { get; set; }
        public long CantidadDisponible { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
