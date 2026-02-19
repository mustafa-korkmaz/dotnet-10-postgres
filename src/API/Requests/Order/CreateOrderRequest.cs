using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "ITEMS")]
        public ICollection<OrderItemRequest>? Items { get; init; }

        [GuidValidation]
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "USER_ID")]
        public string? UserId { get; init; }
    }
}