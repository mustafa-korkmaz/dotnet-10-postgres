using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order
{
    public record OrderItemRequest(
        [GuidValidation]
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "PRODUCT_ID")]
        string? ProductId,

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "UNIT_PRICE")]
        decimal? UnitPrice,

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "QUANTITY")]
        int? Quantity);
}