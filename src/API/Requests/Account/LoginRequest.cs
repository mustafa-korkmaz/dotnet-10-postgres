using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account
{
    public class LoginRequest
    {
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [StringLength(50, ErrorMessage = RequestValidationErrorCodes.MaxLength)]
        [EmailAddress(ErrorMessage = RequestValidationErrorCodes.InvalidField)]
        [Display(Name = "EMAIL")]
        public string? Email { get; init; }

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "PASSWORD")]
        public string? Password { get; init; }
    }
}
