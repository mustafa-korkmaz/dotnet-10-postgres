using System.ComponentModel.DataAnnotations;

namespace API.Requests
{
    public record PaginationRequest(
        bool? IncludeRecordsTotal,

        [Range(0, 10000, ErrorMessage = RequestValidationErrorCodes.BetweenRange)]
        [Display(Name = "OFFSET")]
        int? Offset,

        [Range(1, 1000, ErrorMessage = RequestValidationErrorCodes.BetweenRange)]
        [Display(Name = "LIMIT")]
        int? Limit);
}
