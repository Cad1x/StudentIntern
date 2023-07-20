using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            var currentDate = DateTime.Now;
            var dateOfBirth = date.AddYears(_minimumAge);

            if (dateOfBirth > currentDate)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}