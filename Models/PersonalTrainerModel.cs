using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{

    public enum PersonalTrainerType
    {
        GYM,          // Treinamento geral de academia
        POOL,         // Treinamento em piscina
        STRENGTH,     // Treinamento de força
        ENDURANCE,    // Treinamento de resistência e condicionamento
        FLEXIBILITY,  // Treinamento de flexibilidade e mobilidade
        CARDIO,       // Treinamento cardiovascular
        WEIGHTLOSS,   // Treinamento para perda de peso e redução de gordura
        REHABILITATION, // Reabilitação e recuperação de lesões
        SPORTS,       // Treinamento específico para desempenho esportivo
        YOGA,         // Treinamento de yoga e mindfulness
        PILATES,      // Treinamento baseado em pilates
        NUTRITION,    // Orientação nutricional com foco no treinamento
        FUNCTIONAL,   // Treinamento funcional e força para o dia a dia
        BOOTCAMP,     // Treinamento em grupo de alta intensidade
        KIDS,         // Treinamento físico para crianças
        SENIOR,       // Treinamento físico para idosos
    }

    public class PersonalTrainerModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um endereço de email válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O telefone deve ter exatamente 9 dígitos.")]
        public string? Phone { get; set; } // Use string para facilitar a validação de tamanho

        public PersonalTrainerType Type { get; set; }

    }
}
