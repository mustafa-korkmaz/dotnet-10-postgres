using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account
{
    public record RegisterRequest(
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [StringLength(50, ErrorMessage = RequestValidationErrorCodes.MaxLength)]
        [EmailAddress(ErrorMessage = RequestValidationErrorCodes.InvalidField)]
        [Display(Name = "EMAIL")]
        string? Email,
        
        [StringLength(100, ErrorMessage = RequestValidationErrorCodes.BetweenRange, MinimumLength = 4)]
        [Display(Name = "NAME_SURNAME")]
        string? NameSurname,

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "PASSWORD")]
        string? Password
    );
}
