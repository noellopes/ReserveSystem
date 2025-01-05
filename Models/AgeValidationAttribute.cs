using ReserveSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class AgeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var staff = (Staff)validationContext.ObjectInstance;
        var today = DateTime.Today;
        var age = today.Year - staff.StaffDateOfBirth.Year;

        if (staff.StaffDateOfBirth > today.AddYears(-age))
            age--;

        if (age < 18)
        {
            return new ValidationResult("Staff must be at least 18 years old.");
        }

        return ValidationResult.Success;
    }
}
