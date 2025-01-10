using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Promos
    {
        [Key]
        public int Id_Prom {  get; set; }
       
        public int event_id { get; set; }
        [Required(ErrorMessage ="Please introduce a code for the promo")]
        public String evCode { get; set; }
        [Required(ErrorMessage ="Please introduce a discount for the promo")]
        public float discount { get; set; }
        public bool promState { get; set; }
        [ForeignKey("event_id")]
        public Events Events { get; set; }
    }
}
