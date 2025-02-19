using System.ComponentModel.DataAnnotations;

namespace SkincareBookingApp.Helpers
{
    public class EnumValidationAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public EnumValidationAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !Enum.IsDefined(_enumType, value))
            {
                return new ValidationResult(ErrorMessage ?? $"Invalid value for {_enumType.Name}");
            }

            return ValidationResult.Success;
        }
    }
}