using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.DATA
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Proveedor { get; set; }

        public List<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

        [Required]
        public decimal Total { get; set; }

        public class DetalleCompra
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
            public decimal Precio_Mayorista { get; set; }

            [Required]
            public decimal Precio_Unitario { get; set; }

            public decimal SubTotal { get; set; }

            [Required]
            public int CompraId { get; set; }

            [ForeignKey("CompraId")]
            public Compra Compra { get; set; }

            public decimal CalcularSubTotal(int cantidad, decimal precio)
            {
                decimal subtotal = (precio * cantidad);
                return subtotal;
            }

            public decimal CalcularUnitario(decimal mayorista, int porcentaje)
            {
                decimal unitario = ((mayorista) + (porcentaje * mayorista) / 100);
                return unitario;
            }
        }
    }
}
