using System.ComponentModel.DataAnnotations;

namespace WebApplicationKitap.CustomValidation
{
    public class NameLengthValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            if (string.IsNullOrEmpty(name) || name.Length <= 1)
            {
                return new ValidationResult("Name cannot be less than 1 character");
            }
            return ValidationResult.Success;
        }
    }
}
