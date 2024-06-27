using System.ComponentModel.DataAnnotations;
using BackendProject.Shared.Extensions;

namespace BackendProject.Shared.Annotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class CustomPhoneNumber : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("Phone number is required");

        var str = value.ToString();

        var phoneNumber = str.ToNormalizedPhoneNumber();

        if (!phoneNumber.StartsWith('5'))
            return new ValidationResult("Phone number must start with 5");

        if (phoneNumber.Length != 9)
            return new ValidationResult("Phone number must be exact 9 digits");

        if (!phoneNumber.All(x => char.IsDigit(x)))
        {
            return new ValidationResult("Phone number must contain only numbers");
        }

        return ValidationResult.Success;
    }
}