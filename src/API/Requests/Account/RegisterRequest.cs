using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [StringLength(50, ErrorMessage = RequestValidationErrorCodes.MaxLength)]
        [EmailAddress(ErrorMessage = RequestValidationErrorCodes.InvalidField)]
        [Display(Name = "EMAIL")]
        public string? Email { get; init; }

        [StringLength(100, ErrorMessage = RequestValidationErrorCodes.BetweenRange, MinimumLength = 4)]
        [Display(Name = "NAME_SURNAME")]
        public string? NameSurname { get; init; }

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "PASSWORD")]
        public string? Password { get; init; }
    }
}
