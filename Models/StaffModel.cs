using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
	public class StaffModel
	{

		[Key]
		
		public int StaffId { get; set; }
		[Required, Display(Name = "Staff Name")]
		
		public string Staff_Name { get; set; }
		
		public string Job_Name { get; set; }

		public virtual ICollection<ExcursaoModel>? Excursao { get; set; }


		//public JobTestModel? JobTest { get; set; }

	}
}
