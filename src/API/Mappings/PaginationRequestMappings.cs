using API.Requests;
using Application.Pagination;

namespace API.Mappings
{
    public static class PaginationRequestMappings
    {
        public static PaginationOptions ToPaginationOptions(this PaginationRequest request)
        {
            int offset = request.Offset ?? 0;
            int limit = request.Limit ?? 10;
            bool includeRecordsTotal = request.IncludeRecordsTotal ?? false;

            return
                new PaginationOptions(offset,
                    limit,
                    includeRecordsTotal);
        }
    }
}
