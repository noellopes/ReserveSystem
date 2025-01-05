using ReserveSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class DriversLicenseExpirationDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var staff = (Staff)validationContext.ObjectInstance;
        var today = DateTime.Today;

        if (staff.StaffDriversLicenseExpiringDate <= today)
        {
            return new ValidationResult("Staff's driver's license expiration date must be in the future.");
        }

        return ValidationResult.Success;
    }
}
