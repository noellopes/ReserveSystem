using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;
public class PrecoTipoQuarto: TipoQ
{
		public int precotq_id { get; set; }

		[Required]
		public	float PrecoBase {  get; set; }
	
}
