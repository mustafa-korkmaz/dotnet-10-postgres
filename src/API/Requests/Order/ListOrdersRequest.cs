using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order
{
    public class ListOrdersRequest : PaginationRequest
    {
        [GuidValidation]
        [Display(Name = "USER_ID")]
        public string? UserId { get; init; }
    }
}