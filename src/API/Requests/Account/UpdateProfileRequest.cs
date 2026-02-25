using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account
{
    public record UpdateProfileRequest(
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [StringLength(100, ErrorMessage = RequestValidationErrorCodes.BetweenRange, MinimumLength = 4)]
        [Display(Name = "NAME_SURNAME")]
        string? NameSurname
    );
}
