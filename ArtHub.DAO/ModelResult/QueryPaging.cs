namespace ArtHub.DTO.ModelResult
{
    public class QueryPaging
    {
        public int Page { get; set; } = 0;

        public int PageSize { get; set; } = 10;

        public string? Query { get; set; }
    }

    public class PagedResult<T> where T : class
    {
        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int Page { get; set; }

        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}
