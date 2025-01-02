using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace ReserveSystem.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required]
        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        
        [Range(1, 20)]
        public int? IdMesa { get; set; }
        public int NumeroPessoas { get; set; }

        
        public DateTime DataHora { get; set; }

        public string? Observacao { get; set; }

        public int IdPrato { get; set; }
        public Prato? Prato { get; set; }

        //
        public Boolean Aprovacao { get; set; }
        public int? NumeroMesa { get; internal set; }
    }
}
