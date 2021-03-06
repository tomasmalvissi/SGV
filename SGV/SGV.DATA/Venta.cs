using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.DATA
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public FormasPago FormaPago { get; set; }

        public List<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();

        public int? ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public decimal Total { get; set; }

        public enum FormasPago
        {
            Efectivo = 1,
            MercadoPago = 2,
            Tarjeta = 3
        }

        public class DetalleVenta
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int ProductoId { get; set; }
            [ForeignKey("ProductoId")]
            public Producto Producto { get; set; }

            [Required]
            public int Cantidad { get; set; }

            [Required]
            public int Descuento { get; set; }

            public decimal SubTotal { get; set; }

            [Required]
            public int VentaId { get; set; }

            [ForeignKey("VentaId")]
            public Venta Venta { get; set; }

            public decimal CalcularSubTotal(int cantidad, decimal precio, decimal descuento)
            {
                decimal subtotal = ((precio * cantidad) + (precio * cantidad) * -descuento / 100);
                return subtotal;
            }
        }
    }
}
