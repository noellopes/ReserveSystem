using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Staff
    {
        public int StaffId { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string StaffName { get; set; }

        [Required(ErrorMessage = "O email do funcionário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public required string StaffEmail { get; set; }

        [Required(ErrorMessage = "O telefone do funcionário é obrigatório.")]
        [Phone(ErrorMessage = "O número de telefone fornecido não é válido.")]
        public required string StaffPhone { get; set; }

        [Required(ErrorMessage = "A carta de condução do funcionário é obrigatória.")]
        [StringLength(50, ErrorMessage = "O número da carta de condução deve ter no máximo 50 caracteres.")]
        public required string StaffDriversLicense { get; set; }

        [Required(ErrorMessage = "A data de validade da carta de condução é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime StaffDriversLicenseExpiringDate { get; set; }

        [Required(ErrorMessage = "A data de nascimento do funcionário é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime StaffDateOfBirth { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 100 caracteres.")]
        [DataType(DataType.Password)]
        public required string StaffPassword { get; set; }

        [Required(ErrorMessage = "A data de início das funções é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime StartFunctionsDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime EndFunctionsDate { get; set; }

        [Required(ErrorMessage = "DaysOfVacationCount is required.")]
        [Range(0, 365, ErrorMessage = "DaysOfVacationCount must be 0 to 365.")]
        public required int DaysOfVacationCount { get; set; }

        public bool IsActive { get; set; }

        public int JobId { get; set; }

        public Job job { get; set; }

        public ICollection<Schedules> schedules { get; set; }

        public ICollection<Cleaning_Schedule> cleaningSchedules { get; set; }
    }
}