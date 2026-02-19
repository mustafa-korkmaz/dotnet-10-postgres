namespace Application.Pagination
{
    public sealed record PaginationOptions(
        int Offset,
        int Limit,
        bool IncludeRecordsTotal);
}
