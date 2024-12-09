using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
  
        public class ReservaExcursaoModel
        {
            [Key]
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public int ExcursaoId { get; set; }
            public DateTime DataReserva { get; set; }
            public int NumPessoas { get; set; }

            public int ValorTotal { get; set; }

            // Navigation properties
            public virtual ClienteTestModel? Cliente { get; set; }
            public virtual ExcursaoModel? Excursao { get; set; }
        }

    }

