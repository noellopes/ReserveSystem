using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Transporte
    {
        [Key]
        public int TransporteId { get; set; }

        [Required(ErrorMessage = "O número de matricula é obrigatório.")]
        [StringLength(10,
            ErrorMessage = "O número de matricula não pode ter mais de 10 caracteres e deve ter pelo menos 5 caracteres.",
            MinimumLength = 5)]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "A capacidade é obrigatória.")]
        [Range(1, 500, ErrorMessage = "A capacidade deve estar entre 1 e 500.")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "O tipo de transporte é obrigatório.")]
        [StringLength(50,
            ErrorMessage = "O tipo de transporte não pode ter mais de 50 caracteres e deve ter pelo menos 3 caracteres.",
            MinimumLength = 3)]
        [Display(Name = "Tipo de Transporte")]
        public string TipoTransporte { get; set; }

        [Required(ErrorMessage = "O ano de fabricação é obrigatório.")]
        [Range(1900, 2100, ErrorMessage = "O ano de fabricação deve estar entre 1900 e 2100.")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

        // Propriedade derivada que retorna uma descrição com base no tipo de transporte
        public string DescricaoTipoTransporte
        {
            get
            {
                return TipoTransporte?.ToLower() switch
                {
                    "autocarro" => "Transporte Pesado de Passageiros",
                    "carrinha" => "Transporte alternativo de passageiros ou turismo",
                    _ => "Tipo de transporte desconhecido"
                };
            }
            set
            {
                if (value == "Transporte Pesado de Passageiros")
                {
                    TipoTransporte = "Autocarro";
                }
                else if (value == "Transporte alternativo de passageiros ou turismo")
                {
                    TipoTransporte = "Carrinha";
                }
                else
                {
                    TipoTransporte = "Outro";
                }
            }
        }
    }
    }