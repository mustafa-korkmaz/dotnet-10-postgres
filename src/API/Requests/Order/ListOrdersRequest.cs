using System.ComponentModel.DataAnnotations;

namespace API.Requests.Order
{
    public record ListOrdersRequest(
        [GuidValidation]
        [Display(Name = "USER_ID")]
        string? UserId,
        bool? IncludeRecordsTotal,
        int? Offset,
        int? Limit) : PaginationRequest(IncludeRecordsTotal, Offset, Limit);
}