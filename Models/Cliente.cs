﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ReserveSystem.Models
{
    public class Cliente
    {

        [Key]
        public int IdCliente { get; set; }

        public string NomeCliente { get; set; }

        [Required]
        [MaxLength(8)]
        public  string CC { get; set; }

        [Required]
        [MaxLength(9)]
        public string Telemovel { get; set; }

    }
}
