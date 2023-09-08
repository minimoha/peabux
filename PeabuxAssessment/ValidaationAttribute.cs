using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PeabuxAssessment
{
    public class AllowedTitleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string strRegex = @"Mr|Mrs|Miss|Dr|Prof";
            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (re.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid Title");
        }
    }
}
