using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order
{
    public class OrderItemRequest
    {
        [GuidValidation]
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "PRODUCT_ID")]
        public string? ProductId { get; init; }

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "UNIT_PRICE")]
        public decimal? UnitPrice { get; init; }

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "QUANTITY")]
        public int? Quantity { get; init; }
    }
}