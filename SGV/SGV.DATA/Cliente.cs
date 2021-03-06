using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.DATA
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        [Phone(ErrorMessage = "Debe ingresar números")]
        public int Dni { get; set; }

        public Sexos Sexo { get; set; }

        [Phone(ErrorMessage = "Debe ingresar números")]
        public int Telefono { get; set; }

        public string Direccion { get; set; }

        public enum Sexos
        {
            Masculino = 1,
            Femenino = 2,
            NoDice = 3
        }
    }
}
