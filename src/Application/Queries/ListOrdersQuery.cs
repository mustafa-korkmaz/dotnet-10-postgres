using Application.Pagination;

namespace Application.Queries
{
    public record ListOrdersQuery(
        Guid? UserId,
        PaginationOptions PaginationOptions
    );
}
