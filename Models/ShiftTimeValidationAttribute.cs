using System.ComponentModel.DataAnnotations;

public class ShiftTimeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var schedule = (Schedules)validationContext.ObjectInstance;

        // Verifique se a diferença entre os horários é maior que 8 horas
        var maxShiftDuration = TimeSpan.FromHours(8);
        if (schedule.EndShiftTime - schedule.StartShiftTime > maxShiftDuration)
        {
            return new ValidationResult("The difference between StartShiftTime and EndShiftTime cannot exceed 8 hours.");
        }

        return ValidationResult.Success;
    }
}
