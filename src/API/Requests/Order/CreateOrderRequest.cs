using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order
{
    public record CreateOrderRequest(
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)] [Display(Name = "ITEMS")]
        ICollection<OrderItemRequest>? Items,

        [GuidValidation]
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "USER_ID")]
        string? UserId);
}