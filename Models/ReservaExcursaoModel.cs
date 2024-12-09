using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
  
        public class ReservaExcursaoModel
        {
            [Key]
            public int Id { get; set; }
        [Display(Name = "Nome do Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Excursão")]
        public int ExcursaoId { get; set; }

        [Display(Name = "Data da Reserva")]
            [Column(TypeName = "DATETIME")]
        public DateTime DataReserva { get; set; }

       [ Display(Name = "Numero de Pessoas")]
            public int NumPessoas { get; set; }

       [ Display(Name = "Valor Total")]

            public int ValorTotal { get; set; }

            // Navigation properties
            public virtual ClienteTestModel? Cliente { get; set; }
            public virtual ExcursaoModel? Excursao { get; set; }
        }

    }

