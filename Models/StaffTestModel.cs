using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
	public class StaffTestModel
	{
		[Required, Key, Display(Name = "Staff ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(TypeName = "INTEGER")]
		public int Staff_Id { get; set; }
		[Required, Display(Name = "Staff Name")]
		[Column(TypeName ="TEXT")]
		public string Staff_Name { get; set; }
		[Required, ForeignKey("Job_ID"), Display(Name ="Job ID")]
		[Column(TypeName = "INTEGER")]
		public int Job_ID { get; set; }

		
		//public JobTestModel? JobTest { get; set; }

	}

	
}
