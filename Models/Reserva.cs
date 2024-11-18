﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace ReserveSystem.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        [Required][Range(1, 35)]
        public int NumeroMesa { get; set; }

        [Required(ErrorMessage = "O número da mesa é obrigatório.")]
        [Range(1, 20)]
        public int NumeroPessoas { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        public string? Observacao { get; set; }


    }
}
