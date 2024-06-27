using System.ComponentModel.DataAnnotations;

namespace BackendProject.Shared.Annotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class CustomPersonalId : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("Personal Id is required");

        var str = value.ToString();

        if (str.Length != 11)
            return new ValidationResult("Personal Id must be exact 9 digits");

        if (!str.All(x => char.IsDigit(x)))
        {
            return new ValidationResult("Phone number must contain only numbers");
        }

        return ValidationResult.Success;
    }
}