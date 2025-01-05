using ReserveSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class EndFunctionsDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var staff = (Staff)validationContext.ObjectInstance;

        if (staff.EndFunctionsDate <= staff.StartFunctionsDate)
        {
            return new ValidationResult("EndFunctionsDate must be later than StartFunctionsDate.");
        }

        return ValidationResult.Success;
    }
}
