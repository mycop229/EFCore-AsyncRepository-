using System.ComponentModel.DataAnnotations;

namespace Intership
{
    public class ValidationService
    {
        public bool IsValid<T>(T type) where T : class
        {
            var validationContext = new ValidationContext(type);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(type, validationContext, results, true))
            {
                return true;
            }

            return false;
        }
    }
}
