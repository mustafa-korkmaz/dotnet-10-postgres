namespace Application.Pagination
{
    public sealed record PagedResult<T>(
        IReadOnlyCollection<T> Items,
        int RecordsTotal
    );
}
