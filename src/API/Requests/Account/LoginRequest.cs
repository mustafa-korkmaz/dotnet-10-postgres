using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account
{
    public record LoginRequest(
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [StringLength(50, ErrorMessage = RequestValidationErrorCodes.MaxLength)]
        [EmailAddress(ErrorMessage = RequestValidationErrorCodes.InvalidField)]
        [Display(Name = "EMAIL")]
        string? Email,

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "PASSWORD")]
        string? Password);
}
