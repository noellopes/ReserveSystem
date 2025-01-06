using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Sazonalidade
    {

        [Key]
        public int Id_saz { get; set; }
        [Required]
        [StringLength(25)]
        public string? NameSeason { get; set; }
        [Required]
        public DateTime DateBegin { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public bool InUse { get; set; }
        [Required]
        public float SeasonFee {  get; set; }
    }
}