using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace ReserveSystem.Models
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }

        public int NumeroLugares { get; set; }

        public Boolean Reservado { get; set; }
    }
}
