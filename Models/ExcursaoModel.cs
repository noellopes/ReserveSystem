using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
	public class ExcursaoModel
	{
		[Required, Key, Display(Name = "Excursão ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(TypeName = "INTEGER")]
		public int ExcursaoId { get; set; }

		[Required, Display(Name = "Titulo")]
		
		public string Titulo { get; set; }
		[Required, Display(Name = "Descrição")]
		
		public string Descricao { get; set; }
		[Required, DataType(DataType.DateTime), Display(Name = "Data Inicio"), DisplayFormat(DataFormatString ="{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode =true)]
		[Column(TypeName = "DATETIME")]
		public DateTime Data_Inicio{get; set;}
		[Required, DataType(DataType.DateTime), Display(Name = "Data Fim"), DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
		
		public DateTime Data_Fim { get; set;}
		[Required,DataType(DataType.Currency), Display(Name = "Preço"), DisplayFormat(DataFormatString = "{0:C}")]
		[Column(TypeName = "FLOAT")]
		public float Preco {  get; set;}
		[Required, Display(Name = "Staff ID")]
		[Column(TypeName = "INTEGER")]
		public int StaffId { get; set; }

		public virtual StaffModel? Staff { get; set; }

		public virtual ICollection<PrecarioModel>? Precario { get; set; }

	}

}
