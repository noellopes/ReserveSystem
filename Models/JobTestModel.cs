using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
	public class JobTestModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Job_ID { get; set; }
		[Required]
		public string Job_Name { get; set; }
		public string Job_Description { get; set; }

	}
}
