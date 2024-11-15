using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;
public class Reserva
{
	
        [Key]
        public int numeroReserva {  get; set; }

        [Required]
        public  DateTime dataCheckIn { get; set; }

        [Required]
        public DateTime dataCheckOut { get; set; }

        [Required]
        public DateTime dataReserva { get; set; }

        [Required]
        public DateTime dataCancelamento { get; set; }

       [Required]
        public bool cancelamento { get; set; }

        [Required]
        public string estado { get; set; }

        [Required]
        public bool EstadoPagamento { get; set; }

        [Required]
        public int NumeroPessoas { get; set; }


        [Required]
        public int NumeroCamasAdicional { get; set; }



}
