﻿using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Prato
    {
        [Key]
        public int IdPrato { get; set; }

        [Required]
        public string PratoNome { get; set; }

        public int Preco { get; set; }

        public DayOfWeek Dia { get; set; }

        public string? Descricao { get; set; }

       
    }
}

