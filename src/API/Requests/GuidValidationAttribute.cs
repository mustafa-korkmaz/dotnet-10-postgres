using System.ComponentModel.DataAnnotations;

namespace API.Requests
{
    internal class GuidValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value == null || Guid.TryParse(value.ToString(), out _);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(RequestValidationErrorCodes.InvalidGuidField, name);
        }
    }
}
