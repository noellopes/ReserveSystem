using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
	public class ExcursaoModel
	{
		[Required, Key, Display(Name = "Excursão ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(TypeName = "INTEGER")]
		public int Excursao_Id { get; set; }

		[Required, Display(Name = "Titulo")]
		[Column(TypeName = "TEXT")]
		public string Titulo { get; set; }
		[Required, Display(Name = "Descrição")]
		[Column(TypeName = "TEXT")]
		public string Descricao { get; set; }
		[Required, DataType(DataType.DateTime), Display(Name = "Data Inicio"), DisplayFormat(DataFormatString ="{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode =true)]
		[Column(TypeName = "DATETIME")]
		public DateTime Data_Inicio{get; set;}
		[Required, DataType(DataType.DateTime), Display(Name = "Data Fim"), DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
		[Column(TypeName = "DATE")]
		public DateTime Data_Fim { get; set;}
		[Required,DataType(DataType.Currency), Display(Name = "Preço"), DisplayFormat(DataFormatString = "{0:C}")]
		[Column(TypeName = "FLOAT")]
		public float Preco {  get; set;}
		[Required, Display(Name = "Staff ID")]
		[Column(TypeName = "INTEGER")]
		public int Staff_Id { get; set; }

        //public StaffTestModel? Staff { get; set; }

        public virtual ICollection<ReservaExcursaoModel>? ReservaExcursoes { get; set; }

    }

}
