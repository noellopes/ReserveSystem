using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
	public class JobTestModel
	{
		[Key]
		public int Job_ID { get; set; }
		[Required]
		public string Job_Name { get; set; }
		public string Job_Description { get; set; }

	}
}
