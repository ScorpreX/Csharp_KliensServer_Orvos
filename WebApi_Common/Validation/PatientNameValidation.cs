using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApi_Common.Validation
{
    public class PatientNameValidation : ValidationAttribute
    {
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string nameValue = value.ToString() ?? " ";
            if(!string.IsNullOrWhiteSpace(nameValue))
            {
                if (Regex.IsMatch(nameValue, @"^[A-Za-z ]+$"))
                {

                    return null;
                }
                else
                {
                    return new ValidationResult("A név mező csak alfabetikus karaktereket tartalmazhat!",
                        new[] { validationContext.MemberName });
                }
            }

            return new ValidationResult("A név mező kitöltése kötelező!", new[] { validationContext.MemberName });
        }
    }
}
