using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.DATA
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public Categorias Categoria { get; set; }

        public string? Descripcion { get; set; }

        public string? Url_Detalle { get; set; }

        [Required]
        public decimal PrecioMayorista { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public int Stock { get; set; }


        public enum Categorias
        {
            Alimento = 1,
            Bebida = 2,
            Higiene = 3,
            Limpieza = 4,
            Otro = 5
        }

        public decimal CalcularUnitario(decimal mayorista, int porcentaje)
        {
            decimal unitario = ((mayorista) + (porcentaje * mayorista) / 100);
            return unitario;
        }
    }
}
