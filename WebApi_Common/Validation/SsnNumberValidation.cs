using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace WebApi_Common.Validation
{
    public class SsnNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string ssnValue = value.ToString() ?? " ";

            if (Regex.IsMatch(ssnValue, @"^\d{3} \d{3} \d{3}$"))
            {
                return null;
            }

            return new ValidationResult("A TAJ szám formátuma nem megfelelő!", new[] { validationContext.MemberName });
        }
    }
}
