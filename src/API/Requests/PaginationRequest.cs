using System.ComponentModel.DataAnnotations;

namespace API.Requests
{
    public class PaginationRequest
    {
        public bool? IncludeRecordsTotal { get; init; }

        [Range(0, 1000, ErrorMessage = RequestValidationErrorCodes.BetweenRange)]
        [Display(Name = "OFFSET")]
        public int? Offset { get; init; }

        [Range(1, 1000, ErrorMessage = RequestValidationErrorCodes.BetweenRange)]
        [Display(Name = "LIMIT")]
        public int? Limit { get; init; }
    }
}
