using ReserveSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class VacationDaysValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var staff = (Staff)validationContext.ObjectInstance;

        if (staff.DaysOfVacationCount > 21)
        {
            return new ValidationResult("Vacation days cannot exceed 21 days.");
        }

        return ValidationResult.Success;
    }
}
