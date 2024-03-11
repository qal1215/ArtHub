using ArtHub.DTO.ModelResult;

namespace ArtHub.Service.Helper
{
    public static class CheckPagingQuery
    {
        public static QueryPaging CheckQueryPaging(this QueryPaging queryPaging)
        {
            queryPaging.Page = queryPaging.Page > 0 ? queryPaging.Page : 1;
            queryPaging.PageSize = queryPaging.PageSize > 0 ? queryPaging.PageSize : 9999;
            queryPaging.Query = queryPaging.Query ?? string.Empty;
            return queryPaging;
        }
    }
}
