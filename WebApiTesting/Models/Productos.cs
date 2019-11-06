using System;
using System.Collections.Generic;

namespace WebApiTesting.Models
{
    public partial class Productos
    {
        public long ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Color { get; set; }
        public decimal PrecioUnitario { get; set; }
        public long CantidadDisponible { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
