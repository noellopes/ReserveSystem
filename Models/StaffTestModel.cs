using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
	public class StaffTestModel
	{
		[Key]
		public int Staff_Id { get; set; }
		[Required]
		public string Staff_Name { get; set; }

		public int Job_ID { get; set; }

		
		public JobTestModel? Job { get; set; }

	}

	
}
